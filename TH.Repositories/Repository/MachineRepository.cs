using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Model;
using TH.Repositories.Infrastructure;

namespace TH.Repositories.Repository
{
    public class MachineRepository : RepositoryBase<Machine>, IMachineRepository
    {
        public MachineRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IMachineRepository : IRepository<Machine>
    {
    }
}
