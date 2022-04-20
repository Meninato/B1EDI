using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Cnt
{
    /// <summary>
    /// Cotnrol Total. A segment by which control totals may be provided 
    /// by the sender for checking by the receiver.
    /// </summary>
    public class CntSegment
    {
        /// <summary>
        /// Control total for checking integrity of a message or part of a message.
        /// </summary>
        public CntControl Control { get; set; }

        public override string ToString()
        {
            return $"CNT+{this.Control}'";
        }
    }
}
