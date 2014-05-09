using TH.Model;
using TH.Repositories.Infrastructure;

namespace TH.Repositories.Repository
{
    public class BuyBuildingMaterialRepository : RepositoryBase<BuyBuildingMaterial>, IBuyBuildingMaterialRepository
    {
        public BuyBuildingMaterialRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IBuyBuildingMaterialRepository : IRepository<BuyBuildingMaterial>
    {
    }
}