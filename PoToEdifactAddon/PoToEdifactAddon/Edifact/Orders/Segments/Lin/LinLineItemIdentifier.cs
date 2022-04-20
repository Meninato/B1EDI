using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Lin
{
    /// <summary>
    /// To identify a line item.
    /// </summary>
    public class LinLineItemIdentifier
    {
        /// <summary>
        /// To identify a line item.
        /// </summary>
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Value}";
        }
    }
}
