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
        public string PhotoString { get; set; }
    }
}