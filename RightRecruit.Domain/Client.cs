using System.Collections.Generic;

namespace RightRecruit.Domain
{
    public class Client : Entity
    {
        public string AlternateName { get; set; }
        public string AgreementAttachmentId { get; set; }
        public string ClientLogoAttachmentId { get; set; }
        public Address Address { get; set; }
        public SocialContact Contact { get; set; }
        public ICollection<DenormalizedReference<ClientUser>> Spocs { get; set; }
        public DenormalizedReference<Agency> Agency { get; set; }
        public ICollection<DenormalizedReference<Position>> Positions { get; set; }
        public DenormalizedReference<RevenueModel> RevenueModel { get; set; }
    }
}