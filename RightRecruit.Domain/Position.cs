using System.Collections.Generic;

namespace RightRecruit.Domain
{
    public class Position : Entity
    {
        public DenormalizedReference<Client> Client { get; set; }
        public PositionLevel Level { get; set; }
        public PositionStatus Status { get; set; }
        public ICollection<DenormalizedReference<CandidateStatus>> CandidateStatuses { get; set; }
        public string Skills {get; set;}
        public ICollection<string> Tags {get; set;}
        public int NoOfVacancies {get; set;}
    }
}