using System.Web;
using Raven.Client;
using Raven.Client.Document;

namespace RightRecruit.Mvc.Infrastructure.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDocumentSession DocumentSession
        {
            get { return (DocumentSession)HttpContext.Current.Session[Globals.UnitOfWork]; }
        }
    }
}