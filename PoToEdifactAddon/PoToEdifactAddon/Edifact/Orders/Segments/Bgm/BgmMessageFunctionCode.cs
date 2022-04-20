using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Bgm
{
    /// <summary>
    /// Code indicating the function of the message.
    /// </summary>
    public class BgmMessageFunctionCode
    {
        /// <summary>
        /// Code indicating the function of the message.
        /// </summary>
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Value}";
        }
    }
}
