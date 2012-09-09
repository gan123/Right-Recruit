using System;

namespace RightRecruit.Domain
{
    public class AgencyBranding : Entity
    {
        public DenormalizedReference<Agency> Agency { get; set; }
        public Theme Theme { get; set; }
        public AttachmentReference AgencyLogoAttachment { get; set; }
        public Uri DefaultHomePageUrl { get; set; }
    }
}