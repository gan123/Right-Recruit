namespace RightRecruit.Domain
{
    public class CtcToCutMap : Entity
    {
        public double MinCtc { get; set; }
        public double MaxCtc { get; set; }
        public double PercentageCut { get; set; }
    }
}