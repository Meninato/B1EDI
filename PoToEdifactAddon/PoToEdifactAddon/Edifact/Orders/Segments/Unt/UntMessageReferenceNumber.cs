using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Unt
{
    /// <summary>
    /// Unique message reference assigned by the sender.
    /// </summary>
    public class UntMessageReferenceNumber
    {
        /// <summary>
        /// Unique message reference assigned by the sender.
        /// </summary>
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Value}";
        }
    }
}
