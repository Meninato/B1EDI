using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Unh
{
    /// <summary>
    /// Identification of the type, version, etc. of the message being interchanged.
    /// </summary>
    public class UnhMessageIdentifier
    {
        /// <summary>
        /// Code identifying a type of message and assigned by its controlling agency.
        /// </summary>
        public string MessageType { get; set; }

        /// <summary>
        /// Version number of a message type.
        /// </summary>
        public string MessageVersionNumber { get; set; }

        /// <summary>
        /// Release number within the current message version number.
        /// </summary>
        public string MessageReleaseNumber { get; set; }

        /// <summary>
        /// Code identifying a controlling agency.
        /// </summary>
        public string ControllingAgency { get; set; }

        /// <summary>
        /// Representation of this segment groupd inside the format file
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.MessageType}:{this.MessageVersionNumber}:{this.MessageReleaseNumber}:{this.ControllingAgency}";
        }
    }
}
