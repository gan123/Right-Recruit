using System.Web;

namespace RightRecruit.Mvc.Infrastructure.Infrastructure
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        public CurrentUser CurrentUser
        {
            get { return (CurrentUser)HttpContext.Current.Session[Globals.CurrentUser]; }
        }
    }
}