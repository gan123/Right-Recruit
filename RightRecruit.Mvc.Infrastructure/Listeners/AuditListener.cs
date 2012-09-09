using System;
using System.Web;
using Raven.Client.Listeners;
using Raven.Json.Linq;
using RightRecruit.Domain;
using RightRecruit.Mvc.Infrastructure.Infrastructure;

namespace RightRecruit.Mvc.Infrastructure.Listeners
{
    public class AuditListener : IDocumentStoreListener
    {
        public bool BeforeStore(string key, object entityInstance, RavenJObject metadata, RavenJObject original)
        {
            var entity = entityInstance as Entity;
            if (entity == null) return false;

            var currentUserId = HttpContext.Current.Session[Globals.CurrentUser] == null ? "system" : ((CurrentUser)HttpContext.Current.Session[Globals.CurrentUser]).User.Id;
            if (string.IsNullOrEmpty(entity.CreatedByUserId))
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedByUserId = currentUserId;
            }
            entity.LastUpdatedDate = DateTime.Now;
            entity.LastUpdatedUserId = currentUserId;

            return true;
        }

        public void AfterStore(string key, object entityInstance, RavenJObject metadata)
        {
        }
    }
}