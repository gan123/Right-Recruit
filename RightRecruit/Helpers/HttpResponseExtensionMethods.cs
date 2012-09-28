using System.Web;
using System.Web.Caching;

namespace RightRecruit.Helpers
{
    public static class HttpResponseExtensionMethods
    {
        public static void SetDefaultImageHeaders(this HttpResponseBase response)
        {
            response.Cache.SetCacheability(HttpCacheability.Public);
            response.Cache.SetExpires(Cache.NoAbsoluteExpiration);
            response.Cache.SetLastModifiedFromFileDependencies();
        }
    }
}