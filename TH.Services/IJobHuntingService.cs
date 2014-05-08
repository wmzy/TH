using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Model;

namespace TH.Services
{
    public interface IJobHuntingService : IService
    {
        IQueryable<JobHunting> Get(int pageIndex, int pageSize, out int recordCount);

        void Create(JobHunting job);

        JobHunting GetById(int id);

        void Update(JobHunting jobHunting);

        void OwnerDelete(string ownerId, int id);
    }
}
