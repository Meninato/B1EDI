using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Pia
{
    /// <summary>
    /// Goods identification for a specified source.
    /// </summary>
    public class PiaItemNumberIdentification
    {
        /// <summary>
        /// To identify an item.
        /// </summary>
        public string ItemIdentifier { get; set; }

        /// <summary>
        /// Coded identification of an item type.
        /// </summary>
        public string ItemTypeIdentificationCode { get; set; }

        public override string ToString()
        {
            return $"{this.ItemIdentifier}:{this.ItemTypeIdentificationCode}";
        }
    }
}
