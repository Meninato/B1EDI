using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Edifact.Orders.Segments.Dtm
{
    /// <summary>
    /// Date/Time/Period. A segment specifying general dates and, when relevant, times related to the whole message. 
    /// The segment must be specified at least once to identify the order date. 
    /// Examples of the use of this DTM segment are: Lead times that apply to the whole of the Order and, 
    /// if no schedule is to be specified, the delivery date. The Date/time/period segment within other 
    /// Segment group should be used whenever the date/time/period requires to be logically related to 
    /// another specified data item. e.g. Payment due date is specified within the PYT Segment group.
    /// </summary>
    public class DtmSegment
    {
        public DtmDateTimePeriod DateTimePeriod { get; set; }

        public override string ToString()
        {
            return $"DTM+{this.DateTimePeriod}'";
        }
    }
}
