using TH.Model;
using TH.Repositories.Infrastructure;

namespace TH.Repositories.Repository
{
    public class OtherInfoRepository : RepositoryBase<OtherInfo>, IOtherInfoRepository
    {
        public OtherInfoRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IOtherInfoRepository : IRepository<OtherInfo>
    {
    }
}