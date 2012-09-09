namespace RightRecruit.Domain
{
    public class Candidate : User
    {
        public string CurrentOrganisation { get; set; }
        public double CurrentCtc { get; set; }
        public string NoticePeriod { get; set; }
        public string ExpectedCtc { get; set; }
        public string ResumeAttachmentId { get; set; }
    }
}