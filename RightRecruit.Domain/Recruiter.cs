using System.Collections.Generic;

namespace RightRecruit.Domain
{
    public class Recruiter : User
    {
        public DenormalizedReference<Agency> Agency {get; set;}
        public bool IsManager {get; set;}
        public bool IsTeamLead {get; set;}
        public bool IsAdmin { get; set; }
        public bool IsGlobalAdmin { get; set; }
        public bool IsWorkingFromHome { get; set; }
        public ICollection<DenormalizedReference<JobPortal>> JobPortals {get; set;}
        public int Rating { get; set; }
        public List<DenormalizedReference<Target>> Targets { get; set; }
    }
}