using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Unh
{
    /// <summary>
    /// Message Header. A service segment starting and uniquely identifying a message. The message type code for the Purchase order message is ORDERS.
    /// </summary>
    public class UnhSegment
    {
        /// <summary>
        /// Unique message reference assigned by the sender.
        /// </summary>
        public UnhMessageReferenceNumber MessageReferenceNumber { get; set; }

        /// <summary>
        /// Identification of the type, version, etc. of the message being interchanged.
        /// </summary>
        public UnhMessageIdentifier MessageIdentifier { get; set; }

        /// <summary>
        /// Representation of the entire unh segment
        /// </summary>
        public override string ToString()
        {
            return $"UNH+{this.MessageReferenceNumber}+{this.MessageIdentifier}'";
        }
    }
}
