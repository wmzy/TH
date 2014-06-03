using System.Linq;
using TH.Model;
using TH.Repositories.Infrastructure;

namespace TH.Repositories.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IUserRepository : IRepository<User>
    {
    }
}