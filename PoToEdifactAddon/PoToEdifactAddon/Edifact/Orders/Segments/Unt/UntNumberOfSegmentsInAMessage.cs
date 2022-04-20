using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Unt
{
    /// <summary>
    /// The number of segments in a message body, plus the message header segment and message trailer segment.
    /// </summary>
    public class UntNumberOfSegmentsInAMessage
    {
        /// <summary>
        /// The number of segments in a message body, plus the message header segment and message trailer segment.
        /// </summary>
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Value}";
        }
    }
}
