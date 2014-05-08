namespace TH.Repositories.Infrastructure
{
public class DatabaseFactory : Disposable, IDatabaseFactory
{
    private THDbContext dataContext;
    public THDbContext Get()
    {
        return dataContext ?? (dataContext = new THDbContext());
    }
    protected override void DisposeCore()
    {
        if (dataContext != null)
            dataContext.Dispose();
    }
}
}
