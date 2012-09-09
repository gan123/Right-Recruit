using System.ComponentModel;

namespace RightRecruit.Domain
{
    public enum PositionStatus
    {
        [Description("Open")]
        Open = 1,

        [Description("Closed")]
        Closed = 2,

        [Description("On Hold")]
        OnHold = 3
    }
}