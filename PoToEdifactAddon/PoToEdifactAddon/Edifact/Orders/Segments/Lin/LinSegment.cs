using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Lin
{
    /// <summary>
    /// Line Item. A segment identifying the line item by the line number and configuration level, and additionally, 
    /// identifying the product or service ordered. Other product identification numbers e.g. Buyer product number, etc. 
    /// can be specified within the following PIA segment.
    /// </summary>
    public class LinSegment
    {
        /// <summary>
        /// To identify a line item.
        /// </summary>
        public LinLineItemIdentifier LineItemIdentifier { get; set; }

        /// <summary>
        /// Code specifying the action to be taken or already taken.
        /// </summary>
        public LinActionCode ActionCode { get; set; }

        /// <summary>
        /// Goods identification for a specified source.
        /// </summary>
        public LinItemNumberIdentification ItemNumberIdentification { get; set; }

        public override string ToString()
        {
            return $"LIN+{this.LineItemIdentifier}+{this.ActionCode}+{this.ItemNumberIdentification}'";
        }
    }
}
