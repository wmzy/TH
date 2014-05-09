using TH.Model;
using TH.Repositories.Infrastructure;

namespace TH.Repositories.Repository
{
    public class UseEquipmentRepository : RepositoryBase<UseEquipment>, IUseEquipmentRepository
    {
        public UseEquipmentRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IUseEquipmentRepository : IRepository<UseEquipment>
    {
    }
}