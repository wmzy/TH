using TH.Model;
using TH.Repositories.Infrastructure;

namespace TH.Repositories.Repository
{
    public class RequireCredentialRepository : RepositoryBase<RequireCredential>, IRequireCredentialRepository
    {
        public RequireCredentialRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IRequireCredentialRepository : IRepository<RequireCredential>
    {
    }
}