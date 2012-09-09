namespace RightRecruit.Domain
{
    public class AttachmentReference
    {
        public string AttachmentId { get; set; }

        public static implicit operator AttachmentReference(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
            return new AttachmentReference { AttachmentId = id };
        }
    }
}