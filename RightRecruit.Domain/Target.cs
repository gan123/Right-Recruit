using System;

namespace RightRecruit.Domain
{
    public class Target : Entity
    {
        public DenormalizedReference<Recruiter> Recruiter { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsCurrent { get; set; }
        public Amount TargetedRevenue { get; set; }
        public double PercentageCommission { get; set; }
    }

    public class MonthlyTarget : Target { }
    public class QuarterlyTarget : Target { }
    public class HalfYearlyTarget : Target { }
    public class AnnualTarget : Target { }
}