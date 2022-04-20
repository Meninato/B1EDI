using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Nad
{
    /// <summary>
    /// Name and Address. A segment identifying names and addresses of the parties, in coded or clear form, and their functions relevant to the order.
    /// Identification of the seller and buyer parties is mandatory for the order message. 
    /// It is recommended that where possible only the coded form of the party ID should be specified e.g. 
    /// The Buyer and Seller are known to each other, thus only the coded ID is required, 
    /// but the Consignee or Delivery address may vary and would have to be clearly specified, preferably in structured format.
    /// </summary>
    public class NadSegment
    {
        /// <summary>
        /// Code giving specific meaning to a party.
        /// </summary>
        public NadPartyFunctionCodeQualifier PartyFunctionCodeQualifier { get; set; }

        /// <summary>
        /// Identification of a transaction party by code.
        /// </summary>
        public NadPartyIdentificationDetails PartyIdentificationDetails { get; set; }

        /// <summary>
        /// Unstructured name and address: one to five lines.
        /// </summary>
        public NadNameAndAddress NameAndAddress { get; set; }

        /// <summary>
        /// Identification of a transaction party by name, one to five lines. Party name may be formatted.
        /// </summary>
        public NadPartyName PartyName { get; set; }

        public override string ToString()
        {
            return $"NAD+{this.PartyFunctionCodeQualifier}+{this.PartyIdentificationDetails}+{this.NameAndAddress}+{this.PartyName}'";
        }
    }
}
