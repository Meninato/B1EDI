using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Dtm
{
    /// <summary>
    /// Date and/or time, or period relevant to the specified date/time/period type.
    /// </summary>
    public class DtmDateTimePeriod
    {
        /// <summary>
        /// Code qualifying the function of a date, time or period.
        /// </summary>
        public string DateTimePeriodFunctionCodeQualifier { get; set; }

        /// <summary>
        /// The value of a date, a date and time, a time or of a period in a specified representation.
        /// </summary>
        public string DateTimePeriodText { get; set; }

        /// <summary>
        /// Code specifying the representation of a date, time or period.
        /// </summary>
        public string DateTimePeriodFormatCode { get; set; }

        public override string ToString()
        {
            return $"{this.DateTimePeriodFunctionCodeQualifier}:{this.DateTimePeriodText}:{this.DateTimePeriodFormatCode}";
        }
    }
}
