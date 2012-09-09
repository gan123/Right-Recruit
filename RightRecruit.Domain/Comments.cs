namespace RightRecruit.Domain
{
    public class Comments : Entity
    {
        public DenormalizedReference<CandidateStatus> CandidateStatus { get; set; }
        public string Comment { get; set; }
        public DenormalizedReference<User> User { get; set; }
        public Source Source {get; set;}
    }
}