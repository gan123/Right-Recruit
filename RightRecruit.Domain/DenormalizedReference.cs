namespace RightRecruit.Domain
{
    public class DenormalizedReference<T> where T : INamedDocument
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public static implicit operator DenormalizedReference<T>(T doc)
        {
            return new DenormalizedReference<T>
                       {
                           Id = doc.Id,
                           Name = doc.Name
                       };
        }
    }
}