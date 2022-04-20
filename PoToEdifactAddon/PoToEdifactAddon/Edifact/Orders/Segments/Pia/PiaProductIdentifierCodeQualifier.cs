using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Pia
{
    /// <summary>
    /// Code qualifying the product identifier.
    /// </summary>
    public class PiaProductIdentifierCodeQualifier
    {
        /// <summary>
        /// Code qualifying the product identifier.
        /// </summary>
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Value}";
        }
    }
}
