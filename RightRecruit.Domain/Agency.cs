using System.Collections.Generic;

namespace RightRecruit.Domain
{
    public class Agency : Entity
    {
        public Address Address {get; set;}
        public Contact Contact {get; set;}
        public ICollection<DenormalizedReference<Recruiter>> Recruiters {get; set;}
    }
}