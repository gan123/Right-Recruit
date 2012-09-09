using System.Collections.Generic;

namespace RightRecruit.Domain
{
    public class CtcRangeBasedRevenueModel : RevenueModel
    {
        public ICollection<CtcToCutMap> CtcToCutMaps { get; set; }
    }
}