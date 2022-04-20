using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Uns
{
    /// <summary>
    /// Section Control. A service segment placed at the start of the summary 
    /// section to avoid segment collision.
    /// </summary>
    public class UnsSegment
    {
        /// <summary>
        /// Identification of the separation of sections of a message.
        /// </summary>
        public UnsSectionIdentification SectionIdentification { get; set; }

        public override string ToString()
        {
            return $"UNS+{this.SectionIdentification}'";
        }
    }
}
