using System.Collections.Generic;

namespace RightRecruit.Domain
{
    public class LevelBasedRevenueModel : RevenueModel
    {
        public ICollection<LevelToCutMap> LevelToCutMaps { get; set; }
    }
}