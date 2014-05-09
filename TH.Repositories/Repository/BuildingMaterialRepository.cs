using TH.Model;
using TH.Repositories.Infrastructure;

namespace TH.Repositories.Repository
{
    public class BuildingMaterialRepository : RepositoryBase<BuildingMaterial>, IBuildingMaterialRepository
    {
        public BuildingMaterialRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IBuildingMaterialRepository : IRepository<BuildingMaterial>
    {
    }
}