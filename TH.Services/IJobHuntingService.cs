using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Repositories.Entities;

namespace TH.Services
{
    public interface IJobHuntingService
    {
        IQueryable<JobHunting> GetJobHuntings(int pageIndex, int pageSize, out int recordCount);

        void CreateJobHunting(JobHunting job);

        JobHunting GetJobHuntingById(int id);

        void Update(JobHunting jobHunting);

        void OwnerDelete(string ownerId, int id);
    }
}
