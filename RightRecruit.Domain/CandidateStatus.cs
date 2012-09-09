using System;
using System.Collections.Generic;

namespace RightRecruit.Domain
{
    public class CandidateStatus : Entity
    {
        public DenormalizedReference<Position> PositionAppliedFor { get; set; }
        public DenormalizedReference<Candidate> Candidate { get; set; }
        public DenormalizedReference<InterviewStatus> InterviewStatus { get; set; }
        public DenormalizedReference<Recruiter> SentBy { get; set; }
        public DateTime StatusAsOf { get; set; }
        public ICollection<DenormalizedReference<Comments>> Comments { get; set; }

    }
}