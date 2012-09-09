namespace RightRecruit.Mvc.Infrastructure.Infrastructure
{
    public interface ICurrentUserProvider
    {
        CurrentUser CurrentUser { get; }
    }
}