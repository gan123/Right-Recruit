namespace RightRecruit.Domain
{
    public class LevelToCutMap : Entity
    {
        public PositionLevel PositionLevel { get; set; }
        public double PercentageCut { get; set; }
    }
}