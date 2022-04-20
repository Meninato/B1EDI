using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Bgm
{
    /// <summary>
    /// Identification of a document/message by its number and eventually its version or revision.
    /// </summary>
    public class BgmDocumentMessageIdentification
    {
        /// <summary>
        /// To identify a document.
        /// </summary>
        public string DocumentIdentifier { get; set; }

        public override string ToString()
        {
            return $"{this.DocumentIdentifier}";
        }
    }
}
