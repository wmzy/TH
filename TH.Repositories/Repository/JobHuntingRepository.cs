using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Model;
using TH.Repositories.Infrastructure;

namespace TH.Repositories.Repository
{
    public class JobHuntingRepository : RepositoryBase<JobHunting>, IJobHuntingRepository
    {
        public JobHuntingRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IJobHuntingRepository : IRepository<JobHunting>
    {
    }
}
