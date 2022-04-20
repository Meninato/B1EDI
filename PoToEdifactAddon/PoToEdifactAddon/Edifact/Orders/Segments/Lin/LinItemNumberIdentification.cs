using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Lin
{
    /// <summary>
    /// Goods identification for a specified source.
    /// </summary>
    public class LinItemNumberIdentification
    {
        /// <summary>
        /// To identify an item.
        /// </summary>
        public string ItemIdentifier { get; set; }

        /// <summary>
        /// Coded identification of an item type.
        /// </summary>
        public string ItemTypeIdenfiticationCode { get; set; }

        public override string ToString()
        {
            return $"{this.ItemIdentifier}:{this.ItemTypeIdenfiticationCode}";
        }
    }
}
