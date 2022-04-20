using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Bgm
{
    /// <summary>
    /// Identification of a type of document/message by code or name. Code preferred.
    /// </summary>
    public class BgmDocumentMessageName
    {
        /// <summary>
        /// Code specifying the document name.
        /// </summary>
        public string DocumentNameCode { get; set; }

        /// <summary>
        /// Code identifying a user or association maintained code list.
        /// </summary>
        public string CodeListIdentificationCode { get; set; }

        /// <summary>
        /// Code specifying the agency responsible for a code list.
        /// </summary>
        public string CodeListResponsibleAgencyCode { get; set; }

        /// <summary>
        /// Name of a document.
        /// </summary>
        public string DocumentName { get; set; }

        public override string ToString()
        {
            return $"{this.DocumentNameCode}:{this.CodeListIdentificationCode}:{this.CodeListResponsibleAgencyCode}:{this.DocumentName}";
        }
    }
}
