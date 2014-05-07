using TH.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Services
{
    public interface IJobService : IService
    {
        IQueryable<Job> Get(int pageIndex, int pageSize, out int recordCount);

        IEnumerable<Job> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount);    // 按工作地点分类

        Job GetJobById(int id);
        IQueryable<Job> GetByUserId(string userId);

        void Create(Job job);

        void Update(Job job);

        void OwnerDelete(string ownerId, int id);
    }
}
