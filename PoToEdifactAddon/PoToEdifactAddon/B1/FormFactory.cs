using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon
{
    public static class FormFactory
    {
        public const string B1_ADDON_FORM_TYPE = "FPOEDIFACT";
        public const string B1_BTN_EXPORT = "btnexpt";
        public const string B1_GRID_PO = "pogrid";
        public const string B1_DATATABLE_PO = "podt";

        //I know this is ugly, but i did to avoid using store procedure in this example task
        public const string B1_SINGLE_ORDER_QUERY = @"SELECT 
                                            OPOR.""CardCode"",
	                                        OPOR.""CardName"",
	                                        CAST(OPOR.""DocNum"" AS VARCHAR(20)) AS ""DocNum"",
	                                        OSCN.""ItemCode"",
	                                        OSCN.""Substitute"",
	                                        CAST(POR1.""Price"" AS VARCHAR(20)) AS ""Price"",
	                                        OITM.""BuyUnitMsr"",
	                                        CAST(POR1.""Quantity"" AS VARCHAR(20)) AS ""Quantity"",
                                            CAST(POR1.""LineNum"" AS VARCHAR(20)) AS ""LineNum"",
                                            TO_DATS(OPOR.""DocDate"") AS ""DocDate""
                                        FROM OSCN
                                        INNER JOIN OPOR
                                            ON OSCN.""CardCode"" = OPOR.""CardCode""
                                        INNER JOIN POR1
                                            ON OPOR.""DocEntry"" = POR1.""DocEntry""
                                            AND POR1.""ItemCode"" = OSCN.""ItemCode""
                                        INNER JOIN OITM
                                            ON POR1.""ItemCode"" = OITM.""ItemCode""
                                        WHERE
                                            OPOR.""DocNum"" = '{0}'
                                        ORDER BY POR1.""LineNum"" ASC; ";

        //I know this is ugly, but i did to avoid using store procedure in this example task
        public const string B1_LOAD_ORDER_QUERY = @"SELECT TOP 100
                                            'N' AS ""Check"",
	                                        OPOR.""DocNum"" AS ""Document Number"",
                                            OPOR.""CardCode"" AS ""SupplierCode"",
                                            OPOR.""CardName"" AS ""SupplierName""
                                        FROM OSCN
                                        INNER JOIN OPOR
                                            ON OSCN.""CardCode"" = OPOR.""CardCode""
                                        INNER JOIN POR1
                                            ON OPOR.""DocEntry"" = POR1.""DocEntry""
                                            AND POR1.""ItemCode"" = OSCN.""ItemCode""
                                        GROUP BY
                                            OPOR.""DocNum"",
                                            OPOR.""CardCode"",
                                            OPOR.""CardName""
                                        ORDER BY OPOR.""DocNum"" DESC; ";

        public static SAPbouiCOM.Form CreateForm()
        {
            SAPbouiCOM.Form form = GetAddonForm();
            SAPbouiCOM.DataTable dtPo = GetPoDataTable(form);
            SAPbouiCOM.Grid gridPo = GetPoGrid(form, dtPo);
            SAPbouiCOM.Button btnExport = GetExportButton(form);
            SAPbouiCOM.Button btnCancel = GetCancelButton(form);

            ApplyEventFilter();

            return form;
        }

        private static SAPbouiCOM.Form GetAddonForm()
        {
            SAPbouiCOM.FormCreationParams oFormCreationParams =
                B1Application.GetSboApplication().CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_FormCreationParams);

            oFormCreationParams.FormType = B1_ADDON_FORM_TYPE;
            oFormCreationParams.Modality = SAPbouiCOM.BoFormModality.fm_None;
            oFormCreationParams.BorderStyle = SAPbouiCOM.BoFormBorderStyle.fbs_Fixed;

            SAPbouiCOM.Form form = B1Application.GetSboApplication().Forms.AddEx(oFormCreationParams);
            form.Title = "Export purchase orders to EDIFACT";
            form.ClientWidth = 800;
            form.ClientHeight = 500;
            form.Left = (B1Application.GetSboApplication().Desktop.Width - form.Width) / 2;
            form.Top = (B1Application.GetSboApplication().Desktop.Height - form.Height) / 2;
            form.Mode = SAPbouiCOM.BoFormMode.fm_OK_MODE;

            return form;
        }

        private static SAPbouiCOM.DataTable GetPoDataTable(SAPbouiCOM.Form form)
        {
            SAPbouiCOM.DataTable dtPo = form.DataSources.DataTables.Add(B1_DATATABLE_PO);

            dtPo.Columns.Add("Check", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric, 1);
            dtPo.ExecuteQuery(B1_LOAD_ORDER_QUERY);

            return dtPo;
        }

        private static SAPbouiCOM.Grid GetPoGrid(SAPbouiCOM.Form form, SAPbouiCOM.DataTable dtPo)
        {
            SAPbouiCOM.Item itemGridPo = form.Items.Add(B1_GRID_PO, SAPbouiCOM.BoFormItemTypes.it_GRID);
            itemGridPo.Width = 794;
            itemGridPo.Height = 422;
            itemGridPo.Top = 0;
            itemGridPo.Left = 3;

            SAPbouiCOM.Grid gridPo = itemGridPo.Specific;
            gridPo.DataTable = dtPo;
            gridPo.Columns.Item("Check").Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;

            for (int i = 1; i < gridPo.Columns.Count; i++)
            {
                gridPo.Columns.Item(i).Editable = false;
            }

            gridPo.AutoResizeColumns();

            return gridPo;
        }

        private static SAPbouiCOM.Button GetExportButton(SAPbouiCOM.Form form)
        {
            SAPbouiCOM.Item itemBtnExport = form.Items.Add(B1_BTN_EXPORT, SAPbouiCOM.BoFormItemTypes.it_BUTTON);
            itemBtnExport.Width = 65;
            itemBtnExport.Height = 20;
            itemBtnExport.Left = 45;
            itemBtnExport.Top = 440;
            itemBtnExport.Enabled = true;

            SAPbouiCOM.Button btnExport = itemBtnExport.Specific;
            btnExport.Caption = "Export";

            return btnExport;
        }

        private static SAPbouiCOM.Button GetCancelButton(SAPbouiCOM.Form form)
        {
            SAPbouiCOM.Item itemBtnCancel = form.Items.Add("2", SAPbouiCOM.BoFormItemTypes.it_BUTTON);
            itemBtnCancel.Width = 65;
            itemBtnCancel.Height = 20;
            itemBtnCancel.Left = 119;
            itemBtnCancel.Top = 440;
            itemBtnCancel.Enabled = true;

            return itemBtnCancel.Specific;
        }

        private static void ApplyEventFilter()
        {
            SAPbouiCOM.EventFilters filters = new SAPbouiCOM.EventFilters();
            SAPbouiCOM.EventFilter filter = filters.Add(SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED);
            filter.AddEx(FormFactory.B1_ADDON_FORM_TYPE);

            filter = filters.Add(SAPbouiCOM.BoEventTypes.et_MENU_CLICK);
            filter.AddEx(FormFactory.B1_ADDON_FORM_TYPE);

            B1Application.GetSboApplication().SetFilter(filters);
        }
    }
}
