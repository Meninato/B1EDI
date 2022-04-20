using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Qty
{
    /// <summary>
    /// Quantity. A segment identifying the product quantities e.g. ordered quantity
    /// </summary>
    public class QtySegment
    {
        /// <summary>
        /// Quantity information in a transaction, qualified when relevant.
        /// </summary>
        public QtyQuantityDetails QuantityDetails { get; set; }

        public override string ToString()
        {
            return $"QTY+{this.QuantityDetails}'";
        }
    }
}
