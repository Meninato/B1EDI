using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Uns
{
    /// <summary>
    /// Identification of the separation of sections of a message.
    /// </summary>
    public class UnsSectionIdentification
    {
        /// <summary>
        /// Identification of the separation of sections of a message.
        /// </summary>
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Value}";
        }
    }
}
