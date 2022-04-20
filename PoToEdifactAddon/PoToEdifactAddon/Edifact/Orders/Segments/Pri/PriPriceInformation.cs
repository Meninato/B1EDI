using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Pri
{
    /// <summary>
    /// Identification of price type, price and related details.
    /// </summary>
    public class PriPriceInformation
    {
        /// <summary>
        /// Code qualifying a price.
        /// </summary>
        public string PriceCodeQualifier { get; set; }

        /// <summary>
        /// To specify a price.
        /// </summary>
        public string PriceAmount { get; set; }

        public override string ToString()
        {
            return $"{this.PriceCodeQualifier}:{this.PriceAmount}";
        }
    }
}
