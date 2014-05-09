using TH.Model;
using TH.Repositories.Infrastructure;

namespace TH.Repositories.Repository
{
    public class CredentialRepository : RepositoryBase<Credential>, ICredentialRepository
    {
        public CredentialRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface ICredentialRepository : IRepository<Credential>
    {
    }
}