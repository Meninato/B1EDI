using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Lin
{
    /// <summary>
    /// Code specifying the action to be taken or already taken.
    /// </summary>
    public class LinActionCode
    {
        /// <summary>
        /// Code specifying the action to be taken or already taken.
        /// </summary>
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Value}";
        }
    }
}
