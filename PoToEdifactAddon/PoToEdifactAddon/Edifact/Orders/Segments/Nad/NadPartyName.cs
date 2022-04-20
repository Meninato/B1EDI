using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Nad
{
    /// <summary>
    /// Identification of a transaction party by name, one to five lines. Party name may be formatted.
    /// </summary>
    public class NadPartyName
    {
        /// <summary>
        /// Name of a party.
        /// </summary>
        public string PartyName1 { get; set; }

        /// <summary>
        /// Name of a party.
        /// </summary>
        public string PartyName2 { get; set; }

        /// <summary>
        /// Name of a party.
        /// </summary>
        public string PartyName3 { get; set; }

        /// <summary>
        /// Name of a party.
        /// </summary>
        public string PartyName4 { get; set; }

        /// <summary>
        /// Name of a party.
        /// </summary>
        public string PartyName5 { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.PartyName1)
                && string.IsNullOrEmpty(this.PartyName2)
                && string.IsNullOrEmpty(this.PartyName3)
                && string.IsNullOrEmpty(this.PartyName4)
                && string.IsNullOrEmpty(this.PartyName5))
            {
                return string.Empty;
            }
            else if (string.IsNullOrEmpty(this.PartyName1) == false
                 && string.IsNullOrEmpty(this.PartyName2)
                 && string.IsNullOrEmpty(this.PartyName3)
                 && string.IsNullOrEmpty(this.PartyName4)
                 && string.IsNullOrEmpty(this.PartyName5))
            {
                return $"{this.PartyName1}";
            }
            else
            {
                return $"{this.PartyName1}:{this.PartyName2}:{this.PartyName3}:{this.PartyName4}:{this.PartyName5}";
            }
        }
    }
}
