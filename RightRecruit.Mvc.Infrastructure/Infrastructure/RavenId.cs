namespace RightRecruit.Mvc.Infrastructure.Infrastructure
{
    public class RavenId
    {
        public static string Resolve<T>(string id)
        {
            return string.Format("{0}/{1}",
                                 typeof(T).Name.Pluralize().ToLowerInvariant(), id);
        }
    }
}