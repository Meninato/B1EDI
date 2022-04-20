using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Cnt
{
    /// <summary>
    /// Control total for checking integrity of a message or part of a message.
    /// </summary>
    public class CntControl
    {
        /// <summary>
        /// Code qualifying the type of control of hash total.
        /// </summary>
        public string ControlTotalTypeCodeQualifier { get; set; }

        /// <summary>
        /// To specify the value of a control quantity.
        /// </summary>
        public string ControlTotalQuantity { get; set; }

        public override string ToString()
        {
            return $"{this.ControlTotalTypeCodeQualifier}:{this.ControlTotalQuantity}";
        }
    }
}
