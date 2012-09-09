using System;

namespace RightRecruit.Domain
{
    public class RecruiterIncentives : Entity
    {
        public DenormalizedReference<Recruiter> Recruiter { get; set; }
        public DateTime EarnedDate { get; set; }
        public Amount Commission { get; set; }
    }
}