using System;

namespace RightRecruit.Domain
{
    public class AgencyEarnings : Entity
    {
        public DenormalizedReference<Agency> Agency { get; set; }
        public double? RevenueEarned { get; set; }
        public DenormalizedReference<Recruiter> RecruiterResponsible { get; set; }
        public DateTime AsOfDate { get; set; }
        public DenormalizedReference<Position> ForPosition {get; set;}
    }
}