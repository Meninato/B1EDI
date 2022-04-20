using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Unt
{
    /// <summary>
    /// Message Trailer. A service segment ending a message, giving the total number of segments 
    /// in the message (including the UNH & UNT) and the control reference number of the message.
    /// </summary>
    public class UntSegment
    {
        /// <summary>
        /// The number of segments in a message body, plus the message header segment and message trailer segment.
        /// </summary>
        public UntNumberOfSegmentsInAMessage NumberOfSegmentsInAMessage { get; set; }

        /// <summary>
        /// Unique message reference assigned by the sender.
        /// </summary>
        public UntMessageReferenceNumber MessageReferenceNumber { get; set; }

        public override string ToString()
        {
            return $"UNT+{this.NumberOfSegmentsInAMessage}:{this.MessageReferenceNumber}'";
        }
    }
}
