using Raven.Client;

namespace RightRecruit.Mvc.Infrastructure.Infrastructure
{
    public interface IUnitOfWork
    {
        IDocumentSession DocumentSession { get; }
    }
}