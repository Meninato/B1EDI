using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Pia
{
    /// <summary>
    /// Additional product ID. A segment providing either additional identification to the product specified in the LIN segment
    /// (e.g. Harmonized System number), or provides any substitute product identification.
    /// </summary>
    public class PiaSegment
    {
        /// <summary>
        /// Code qualifying the product identifier.
        /// </summary>
        public PiaProductIdentifierCodeQualifier ProductIdentifierCodeQualifier { get; set; }

        /// <summary>
        /// Goods identification for a specified source.
        /// </summary>
        public PiaItemNumberIdentification ItemNumberIdentification { get; set; }

        public override string ToString()
        {
            return $"PIA+{this.ProductIdentifierCodeQualifier}+{this.ItemNumberIdentification}'";
        }
    }
}
