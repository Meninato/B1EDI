using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Bgm
{
    /// <summary>
    /// Beginning of a Message. A segment by which the sender must uniquely identify the order by means of its name and number and when necessary its function.
    /// </summary>
    public class BgmSegment
    {
        /// <summary>
        /// Identification of a type of document/message by code or name. Code preferred.
        /// </summary>
        public BgmDocumentMessageName DocumentMessageName { get; set; }

        /// <summary>
        /// Identification of a document/message by its number and eventually its version or revision.
        /// </summary>
        public BgmDocumentMessageIdentification DocumentMessageIdentification { get; set; }

        /// <summary>
        /// Code indicating the function of the message.
        /// </summary>
        public BgmMessageFunctionCode MessageFunctionCode { get; set; }

        public override string ToString()
        {
            return $"BGM+{this.DocumentMessageName}+{this.DocumentMessageIdentification}+{this.MessageFunctionCode}'";
        }
    }
}
