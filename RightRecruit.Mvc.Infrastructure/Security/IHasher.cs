namespace RightRecruit.Mvc.Infrastructure.Security
{
    public interface IHasher
    {
        int SaltSize { get; set; }
        string Encrypt(string original);
        bool CompareStringToHash(string s, string hash);
    }
}