using PoToEdifactAddon.B1;
using PoToEdifactAddon.Edifact.Orders;
using PoToEdifactAddon.Edifact.Orders.Segments.Bgm;
using PoToEdifactAddon.Edifact.Orders.Segments.Cnt;
using PoToEdifactAddon.Edifact.Orders.Segments.Dtm;
using PoToEdifactAddon.Edifact.Orders.Segments.Lin;
using PoToEdifactAddon.Edifact.Orders.Segments.Nad;
using PoToEdifactAddon.Edifact.Orders.Segments.Pia;
using PoToEdifactAddon.Edifact.Orders.Segments.Pri;
using PoToEdifactAddon.Edifact.Orders.Segments.Qty;
using PoToEdifactAddon.Edifact.Orders.Segments.Unh;
using PoToEdifactAddon.Edifact.Orders.Segments.Uns;
using PoToEdifactAddon.Edifact.Orders.Segments.Unt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Events
{
    public static partial class B1ApplicationEventHandler
    {
        private static void B1ItemEventHandlerAction(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            if(pVal.FormTypeEx == FormFactory.B1_ADDON_FORM_TYPE && pVal.BeforeAction)
            {
                if(pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED)
                {
                    //User hit the export button
                    if (pVal.ItemUID == FormFactory.B1_BTN_EXPORT)
                    {
                        SAPbouiCOM.Form form = B1Application.GetSboApplication().Forms.ActiveForm;
                        SAPbouiCOM.DataTable dt = form.DataSources.DataTables.Item(FormFactory.B1_DATATABLE_PO);

                        //Retrieve the datatable and get the XML representation for fast processing
                        string dataAsXml = dt.SerializeAsXML(SAPbouiCOM.BoDataTableXmlSelect.dxs_DataOnly);
                        System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();
                        xmlDocument.LoadXml(dataAsXml);

                        //Get only the Checked documents
                        System.Xml.XmlNodeList nodeList = 
                            xmlDocument.SelectNodes("/DataTable/Rows/Row/Cells[./Cell[ColumnUid = 'Check' and Value = 'Y']]");

                        //Create EDIFACT files
                        if (nodeList.Count > 0)
                        {
                            //Notify the user about file processing
                            B1Application.GetSboApplication().SetStatusBarMessage("Generating EDI files...", SAPbouiCOM.BoMessageTime.bmt_Short, false);

                            //For every PO get the information needed with help of recordset.
                            //It also could be done with ADO (more fast).
                            SAPbobsCOM.Recordset oRecordset = 
                                B1Application.GetDiCompany().GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                            //Will handle and create our EDI
                            EdifactOrder edifactOrder = new EdifactOrder();

                            //List of OrderData from database
                            //Order Data contains the multiples lines of items and header info
                            List<OrderData> orderDataList = new List<OrderData>();

                            for (int row = 0; row < nodeList.Count; row++)
                            {
                                //Get the docNum from datatable xml
                                string documentNumber = nodeList[row].SelectSingleNode("Cell[ColumnUid='Document Number']/Value").InnerText;
                               
                                try
                                {
                                    //Grab a list of orders data items
                                    orderDataList = GetOrderDataListFromRecordSet(oRecordset, documentNumber);

                                    //Process and create the EDI file into a folder located on the current user directory
                                    //Order Data contains the multiples lines of items and header info
                                    edifactOrder.Generate(orderDataList);
                                }
                                catch(Exception ex)
                                {
                                    B1Application.GetSboApplication().SetStatusBarMessage(
                                        "Something went wrong and the EDI for PO number: " + documentNumber + " was not created. Error: " + ex.Message,
                                        SAPbouiCOM.BoMessageTime.bmt_Short);
                                }
     
                            }

                            //Notify end of process
                            B1Application.GetSboApplication().SetStatusBarMessage("Files were created.", SAPbouiCOM.BoMessageTime.bmt_Short, false);

                            B1Application.ReleaseComObject(oRecordset);
                        }
                        else
                        {
                            B1Application.GetSboApplication().SetStatusBarMessage("No orders to process");
                        }

                        B1Application.ReleaseComObject(form);
                        B1Application.ReleaseComObject(dt);
                    }
                }
            }
        }

        private static List<OrderData> GetOrderDataListFromRecordSet(SAPbobsCOM.Recordset oRecordset, string documentNumber)
        {
            List<OrderData> orderDataList = new List<OrderData>();
            oRecordset.DoQuery(string.Format(FormFactory.B1_SINGLE_ORDER_QUERY, documentNumber));
            while (oRecordset.EoF == false)
            {
                //Extract values from recordset into poco object
                OrderData data = GetOrderDataFromRecordset(oRecordset);

                //Add the items to the order data list
                //Order Data contains the multiples lines of items and header info
                orderDataList.Add(data);

                oRecordset.MoveNext();
            }

            return orderDataList;
        }

        /// <summary>
        /// Extract data from a recordset object into a model object
        /// </summary>
        /// <param name="recordset">Recordset object</param>
        /// <returns>OrderData object that contains the items and header info</returns>
        private static OrderData GetOrderDataFromRecordset(SAPbobsCOM.Recordset recordset)
        {
            OrderData data = new OrderData();
            data.CardCode = recordset.Fields.Item("CardCode").Value;
            data.CardName = recordset.Fields.Item("CardName").Value;
            data.DocNum = recordset.Fields.Item("DocNum").Value;
            data.ItemCode = recordset.Fields.Item("ItemCode").Value;
            data.Substitute = recordset.Fields.Item("Substitute").Value;
            data.Price = recordset.Fields.Item("Price").Value;
            data.BuyUnitMsr = recordset.Fields.Item("BuyUnitMsr").Value;
            data.Quantity = recordset.Fields.Item("Quantity").Value;
            data.LineNum = recordset.Fields.Item("LineNum").Value;
            data.DocDate = recordset.Fields.Item("DocDate").Value;

            return data;
        }
    }
}
