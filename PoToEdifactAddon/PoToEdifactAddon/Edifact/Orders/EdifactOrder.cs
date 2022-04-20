using PoToEdifactAddon.B1;
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders
{
    public class EdifactOrder
    {
        private int _ordersCount = 1;
        private StringBuilder _orderBuilder = new StringBuilder();

        public DirectoryInfo OutputDirectory { get; set; } 
            = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "EDI_EXAMPLE"));

        public List<OrderData> Data { get; set; }

        public EdifactOrder() { }

        public EdifactOrder(List<OrderData> data)
        {
            this.Data = data;
        }

        public void Generate(List<OrderData> data, string outputDirectory = null)
        {
            if (data == null)
                throw new ArgumentNullException("OrderData cannot be null");

            if (string.IsNullOrEmpty(outputDirectory) == false)
                this.OutputDirectory = new DirectoryInfo(outputDirectory);

            if (OutputDirectory.Exists == false)
                OutputDirectory.Create();

            this.Data = data;
            this._orderBuilder.Clear();

            //The OrderData has information of the header and the items
            //So, because of this we just pass one single object to fill header information
            OrderData headerData = data.First();

            UnhSegment unh = CreateUnhSegment();
            BgmSegment bgm = CreateBgmSegment(headerData);
            DtmSegment dtm = CreateDtmSegment(headerData);
            NadSegment nad = CreateNadSegment(headerData);

            _orderBuilder.AppendLine(unh.ToString());
            _orderBuilder.AppendLine(bgm.ToString());
            _orderBuilder.AppendLine(dtm.ToString());
            _orderBuilder.AppendLine(nad.ToString());

            for (int line = 0; line < data.Count; line++)
            {
                OrderData lineData = data[line];
                LinSegment lin = CreateLinSegment(lineData);
                PiaSegment pia = CreatePiaSegment(lineData);
                QtySegment qty = CreateQtySegment(lineData);
                PriSegment pri = CreatePriSegment(lineData);

                _orderBuilder.AppendLine(lin.ToString());
                _orderBuilder.AppendLine(pia.ToString());
                _orderBuilder.AppendLine(qty.ToString());
                _orderBuilder.AppendLine(pri.ToString());
            }

            UnsSegment uns = CreateUnsSegment();
            CntSegment cnt = CreateCntSegment(data.Count.ToString());

            //Number of fixed segments 7, number of var segments OrderData * 4
            UntSegment unt = CreateUntSegment((7 + (data.Count * 4)).ToString());

            _orderBuilder.AppendLine(uns.ToString());
            _orderBuilder.AppendLine(cnt.ToString());
            _orderBuilder.AppendLine(unt.ToString());

            string filename = Path.Combine(this.OutputDirectory.FullName, headerData.DocNum + ".txt");
            using (StreamWriter sw = new StreamWriter(filename, false))
            {
                sw.Write(_orderBuilder.ToString());
            }

        }

        /// <summary>
        /// Create a UNH segment
        /// Example UNH+1+ORDERS:D:21A:UN' 
        /// </summary>
        /// <returns></returns>
        private UnhSegment CreateUnhSegment()
        {
            UnhSegment unh = new UnhSegment();
            unh.MessageReferenceNumber = new UnhMessageReferenceNumber();
            unh.MessageReferenceNumber.Value = _ordersCount.ToString();

            unh.MessageIdentifier = new UnhMessageIdentifier();                             
            unh.MessageIdentifier.MessageType = "ORDERS";
            unh.MessageIdentifier.MessageVersionNumber = "D";
            unh.MessageIdentifier.MessageReleaseNumber = "21A";
            unh.MessageIdentifier.ControllingAgency = "UN";

            return unh;
        }

        /// <summary>
        /// Create a BGM Segment
        /// Example BGM+220:::Purchase Order+DN123457+9'
        /// </summary>
        /// <param name="singleDataObj">OrderData that contains header information</param>
        /// <returns></returns>
        private BgmSegment CreateBgmSegment(OrderData singleDataObj)
        {
            BgmSegment bgm = new BgmSegment();                                              
            bgm.DocumentMessageName = new BgmDocumentMessageName();                         
            bgm.DocumentMessageName.DocumentNameCode = "220";
            bgm.DocumentMessageName.CodeListIdentificationCode = "";
            bgm.DocumentMessageName.CodeListResponsibleAgencyCode = "";
            bgm.DocumentMessageName.DocumentName = "Purchase Order";

            bgm.DocumentMessageIdentification = new BgmDocumentMessageIdentification();     
            bgm.DocumentMessageIdentification.DocumentIdentifier = singleDataObj.DocNum;

            bgm.MessageFunctionCode = new BgmMessageFunctionCode();                         
            bgm.MessageFunctionCode.Value = "9";

            return bgm;
        }

        /// <summary>
        /// Create a DTM Segment
        /// Example DTM+137:20220418:102'
        /// </summary>
        /// <param name="singleDataObj">OrderData that contains header information</param>
        /// <returns></returns>
        private DtmSegment CreateDtmSegment(OrderData singleDataObj)
        {
            DtmSegment dtm = new DtmSegment();                                              
            dtm.DateTimePeriod = new DtmDateTimePeriod();                                   
            dtm.DateTimePeriod.DateTimePeriodFunctionCodeQualifier = "137";
            dtm.DateTimePeriod.DateTimePeriodText = singleDataObj.DocDate;
            dtm.DateTimePeriod.DateTimePeriodFormatCode = "102";

            return dtm;
        }

        /// <summary>
        /// Create a NAD Segment
        /// Example NAD+SU+F000001::ZZZ++CompanyA'
        /// </summary>
        /// <param name="singleDataObj">OrderData that contains header information</param>
        /// <returns></returns>
        private NadSegment CreateNadSegment(OrderData singleDataObj)
        {
            NadSegment nad = new NadSegment();                                              
            nad.PartyFunctionCodeQualifier = new NadPartyFunctionCodeQualifier();           
            nad.PartyFunctionCodeQualifier.Value = "SU";

            nad.PartyIdentificationDetails = new NadPartyIdentificationDetails();           
            nad.PartyIdentificationDetails.PartyIdentifier = singleDataObj.CardCode;
            nad.PartyIdentificationDetails.CodeListIdentificationCode = "";
            nad.PartyIdentificationDetails.CodeListResponsibleAgencyCode = "ZZZ";

            nad.NameAndAddress = new NadNameAndAddress();                                  

            nad.PartyName = new NadPartyName();                                             
            nad.PartyName.PartyName1 = singleDataObj.CardName;

            return nad;
        }

        /// <summary>
        /// Create a LIN Segment
        /// Example LIN+1++SUPPLIERCODE:SA'
        /// </summary>
        /// <param name="lineData">OrderData that contains line information</param>
        /// <returns></returns>
        private LinSegment CreateLinSegment(OrderData lineData)
        {
            LinSegment lin = new LinSegment();
            lin.LineItemIdentifier = new LinLineItemIdentifier();
            lin.LineItemIdentifier.Value = lineData.LineNum;

            lin.ActionCode = new LinActionCode();

            lin.ItemNumberIdentification = new LinItemNumberIdentification();
            lin.ItemNumberIdentification.ItemIdentifier = lineData.Substitute;
            lin.ItemNumberIdentification.ItemTypeIdenfiticationCode = "SA";

            return lin;
        }

        /// <summary>
        /// Create a PIA Segment
        /// Example PIA+1+BUYERCODE:BP'
        /// </summary>
        /// <param name="lineData">OrderData that contains line information</param>
        /// <returns></returns>
        private PiaSegment CreatePiaSegment(OrderData lineData)
        {
            PiaSegment pia = new PiaSegment();
            pia.ProductIdentifierCodeQualifier = new PiaProductIdentifierCodeQualifier();
            pia.ProductIdentifierCodeQualifier.Value = "1";

            pia.ItemNumberIdentification = new PiaItemNumberIdentification();
            pia.ItemNumberIdentification.ItemIdentifier = lineData.ItemCode;
            pia.ItemNumberIdentification.ItemTypeIdentificationCode = "BP";

            return pia;
        }


        /// <summary>
        /// Create a QTY Segment
        /// Example QTY+21:1000:EACH'
        /// </summary>
        /// <param name="lineData">OrderData that contains line information</param>
        /// <returns></returns>
        private QtySegment CreateQtySegment(OrderData lineData)
        {
            QtySegment qty = new QtySegment();                                              // QTY+21:1000:EACH'
            qty.QuantityDetails = new QtyQuantityDetails();                                 // 21:1000:EACH
            qty.QuantityDetails.QuantityTypeCodeQualifier = "21";
            qty.QuantityDetails.Quantity = lineData.Quantity;
            qty.QuantityDetails.MeasurementUnitCode = lineData.BuyUnitMsr;

            return qty;
        }

        /// <summary>
        /// Create a PRI Segment
        /// Example PRI+AAA:6.66'
        /// </summary>
        /// <param name="lineData">OrderData that contains line information</param>
        /// <returns></returns>
        private PriSegment CreatePriSegment(OrderData lineData)
        {
            PriSegment pri = new PriSegment();
            pri.PriceInformation = new PriPriceInformation();
            pri.PriceInformation.PriceCodeQualifier = "AAA";
            pri.PriceInformation.PriceAmount = lineData.Price;

            return pri;
        }

        /// <summary>
        /// Create a UNS segment
        /// Example UNS+S'
        /// </summary>
        /// <returns></returns>
        private UnsSegment CreateUnsSegment()
        {
            UnsSegment uns = new UnsSegment();
            uns.SectionIdentification = new UnsSectionIdentification();
            uns.SectionIdentification.Value = "S";

            return uns;
        }

        /// <summary>
        /// Create a CNT Segment
        /// Example CNT+2:1'
        /// </summary>
        /// <param name="totalLineItems">The total number of lines items</param>
        /// <returns></returns>
        private CntSegment CreateCntSegment(string totalLineItems)
        {
            CntSegment cnt = new CntSegment();
            cnt.Control = new CntControl();
            cnt.Control.ControlTotalTypeCodeQualifier = "2";
            cnt.Control.ControlTotalQuantity = totalLineItems;

            return cnt;
        }

        /// <summary>
        /// Create a UNT Segment
        /// Example UNT+11+1'
        /// </summary>
        /// <param name="numberOfSegments"></param>
        /// <returns></returns>
        private UntSegment CreateUntSegment(string numberOfSegments)
        {
            UntSegment unt = new UntSegment();
            unt.NumberOfSegmentsInAMessage = new UntNumberOfSegmentsInAMessage();
            unt.NumberOfSegmentsInAMessage.Value = numberOfSegments;

            unt.MessageReferenceNumber = new UntMessageReferenceNumber();
            unt.MessageReferenceNumber.Value = _ordersCount.ToString();

            return unt;
        }
    }
}
