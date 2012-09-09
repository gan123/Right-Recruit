using System.ComponentModel;

namespace RightRecruit.Domain
{
    public enum PositionLevel
    {
        [Description("Junior")]
        Junior = 1,

        [Description("Mid level")]
        Mid = 2,

        [Description("Senior level")]
        Senior = 3
    }
}