namespace RightRecruit.Domain
{
    public class State : Entity
    {
        public DenormalizedReference<Country> Country { get; set; }
    }
}