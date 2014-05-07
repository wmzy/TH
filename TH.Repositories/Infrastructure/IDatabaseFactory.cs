using System;

namespace TH.Repositories.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        THDbContext Get();
    }
}
