using System;
using System.Web;
using System.Web.Caching;

namespace RightRecruit.Mvc.Infrastructure.CacheProvider
{
    public class CacheProvider : ICacheProvider
    {
        public void Insert(string key, object data)
        {
            if (!HasKey(key))
                HttpContext.Current.Cache.Insert(key, data, null, Cache.NoAbsoluteExpiration, TimeSpan.FromHours(24));
        }

        public object Get(string key)
        {
            if (HasKey(key))
                return HttpContext.Current.Cache.Get(key);
            return null;
        }

        public bool HasKey(string key)
        {
            return HttpContext.Current.Cache[key] != null;
        }
    }
}