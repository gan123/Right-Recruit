namespace RightRecruit.Mvc.Infrastructure.CacheProvider
{
    public interface ICacheProvider
    {
        void Insert(string key, object data);
        object Get(string key);
        bool HasKey(string key);
    }
}