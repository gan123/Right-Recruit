namespace RightRecruit.Domain
{
    public class City : Entity
    {
        public DenormalizedReference<State> State { get; set; }
    }
}