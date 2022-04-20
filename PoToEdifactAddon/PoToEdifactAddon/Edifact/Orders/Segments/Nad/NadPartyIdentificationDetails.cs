using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Nad
{
    /// <summary>
    /// Identification of a transaction party by code.
    /// </summary>
    public class NadPartyIdentificationDetails
    {
        /// <summary>
        /// Code specifying the identity of a party.
        /// </summary>
        public string PartyIdentifier { get; set; }

        /// <summary>
        /// Code identifying a user or association maintained code list.
        /// </summary>
        public string CodeListIdentificationCode { get; set; }

        /// <summary>
        /// Code specifying the agency responsible for a code list.
        /// </summary>
        public string CodeListResponsibleAgencyCode { get; set; }

        public override string ToString()
        {
            return $"{this.PartyIdentifier}:{this.CodeListIdentificationCode}:{this.CodeListResponsibleAgencyCode}";
        }
    }
}
