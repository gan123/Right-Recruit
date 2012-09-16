namespace RightRecruit.Domain
{
    public class ClientUser : User
    {
        public DenormalizedReference<Client> Client {get; set;}
    }
}