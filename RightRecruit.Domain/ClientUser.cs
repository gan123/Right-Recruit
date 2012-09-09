namespace RightRecruit.Domain
{
    public class ClientUser : Entity
    {
        public DenormalizedReference<Client> Client {get; set;}
        public Contact Contact {get; set;}
    }
}