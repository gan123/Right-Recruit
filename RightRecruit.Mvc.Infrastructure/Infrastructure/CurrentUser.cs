using System;
using RightRecruit.Domain;

namespace RightRecruit.Mvc.Infrastructure.Infrastructure
{
    public class CurrentUser
    {
        public CurrentUser(User user)
        {
            User = user;
        }

        public User User { get; private set; }
        public bool IsAuthenticated { get; set; }
        public DateTime LoggedInTime { get; set; }
        public string Photo { get; set; }
        public string PhotoUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(Photo))
                    return "/rr/image/50/50/" + Photo.Split('.')[0];
                return null;
            }
        }
    }
}