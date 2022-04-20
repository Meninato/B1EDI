using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.B1
{
    public class OrderData
    {
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string DocNum { get; set; }
        public string ItemCode { get; set; }
        public string Substitute { get; set; }
        public string Price { get; set; }
        public string BuyUnitMsr { get; set; }
        public string Quantity { get; set; }
        public string LineNum { get; set; }
        public string DocDate { get; set; }

        public OrderData() { }

        public OrderData(string cardCode, string cardName, 
            string docNum, string itemCode, string substitute, 
            string price, string buyUnitMsr, string quantity, 
            string lineNum, string docDate)
        {
            this.CardCode = cardCode;
            this.CardName = cardName;
            this.DocNum = docNum;
            this.ItemCode = itemCode;
            this.Substitute = substitute;
            this.Price = price;
            this.BuyUnitMsr = buyUnitMsr;
            this.Quantity = quantity;
            this.LineNum = lineNum;
            this.DocDate = docDate;
        }
    }
}
