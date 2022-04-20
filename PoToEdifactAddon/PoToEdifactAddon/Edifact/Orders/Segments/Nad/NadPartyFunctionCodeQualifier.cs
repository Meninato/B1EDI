using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Nad
{
    /// <summary>
    /// Code giving specific meaning to a party.
    /// </summary>
    public class NadPartyFunctionCodeQualifier
    {
        /// <summary>
        /// Code giving specific meaning to a party.
        /// </summary>
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Value}";
        }
    }
}
