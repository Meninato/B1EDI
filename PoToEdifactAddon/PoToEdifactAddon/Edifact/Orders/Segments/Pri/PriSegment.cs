using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Pri
{
    /// <summary>
    /// Price. A segment to specify the price type and amount. 
    /// The price used in the calculation of the line amount will be identified as 'price'.
    /// </summary>
    public class PriSegment
    {
        /// <summary>
        /// Identification of price type, price and related details.
        /// </summary>
        public PriPriceInformation PriceInformation { get; set; }

        public override string ToString()
        {
            return $"PRI+{this.PriceInformation}'";
        }
    }
}
