using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Qty
{
    /// <summary>
    /// Quantity information in a transaction, qualified when relevant.
    /// </summary>
    public class QtyQuantityDetails
    {
        /// <summary>
        /// Code qualifying the type of quantity.
        /// </summary>
        public string QuantityTypeCodeQualifier { get; set; }

        /// <summary>
        /// Alphanumeric representation of a quantity.
        /// </summary>
        public string Quantity { get; set; }

        /// <summary>
        /// Code specifying the unit of measurement.
        /// </summary>
        public string MeasurementUnitCode { get; set; }

        public override string ToString()
        {
            return $"{this.QuantityTypeCodeQualifier}:{this.Quantity}:{this.MeasurementUnitCode}";
        }
    }
}
