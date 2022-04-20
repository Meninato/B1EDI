using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Unh
{
    /// <summary>
    /// Unique message reference assigned by the sender.
    /// </summary>
    public class UnhMessageReferenceNumber
    {
        /// <summary>
        /// MessageReferenceNumber value. Unique message reference assigned by the sender.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Representation of this segment groupd inside the format file
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.Value}";
        }
    }
}
