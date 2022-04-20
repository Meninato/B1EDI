using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Nad
{
    /// <summary>
    /// Unstructured name and address: one to five lines.
    /// </summary>
    public class NadNameAndAddress
    {
        /// <summary>
        /// Free form description of a name and address line.
        /// </summary>
        public string NameAndAddressDescription1 { get; set; }

        /// <summary>
        /// Free form description of a name and address line.
        /// </summary>
        public string NameAndAddressDescription2 { get; set; }

        /// <summary>
        /// Free form description of a name and address line.
        /// </summary>
        public string NameAndAddressDescription3 { get; set; }

        /// <summary>
        /// Free form description of a name and address line.
        /// </summary>
        public string NameAndAddressDescription4 { get; set; }

        /// <summary>
        /// Free form description of a name and address line.
        /// </summary>
        public string NameAndAddressDescription5 { get; set; }

        public override string ToString()
        {
            if(    string.IsNullOrEmpty(this.NameAndAddressDescription1) 
                && string.IsNullOrEmpty(this.NameAndAddressDescription2)
                && string.IsNullOrEmpty(this.NameAndAddressDescription3)
                && string.IsNullOrEmpty(this.NameAndAddressDescription4)
                && string.IsNullOrEmpty(this.NameAndAddressDescription5))
            {
                return string.Empty;
            }
            else if(string.IsNullOrEmpty(this.NameAndAddressDescription1) == false
                 && string.IsNullOrEmpty(this.NameAndAddressDescription2)
                 && string.IsNullOrEmpty(this.NameAndAddressDescription3)
                 && string.IsNullOrEmpty(this.NameAndAddressDescription4)
                 && string.IsNullOrEmpty(this.NameAndAddressDescription5))
            {
                return $"{this.NameAndAddressDescription1}";
            }
            else
            {
                return $"{this.NameAndAddressDescription1}:{this.NameAndAddressDescription2}:{this.NameAndAddressDescription3}:{this.NameAndAddressDescription4}:{this.NameAndAddressDescription5}";
            }
        }
    }
}
