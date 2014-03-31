using TH.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Repositories
{
    public class JobRepository : THRepository<Job>, IJobRepository
    {
        public JobRepository(THDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEnumerable<Job> GetJobs(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = this.DbSet.Count();
            return this.Get(f => true, pageIndex, pageSize, f => f.CreatedDate, false);
        }

        public Job GetJob(int FullTimeJobId)
        {
            return this.Get(f => f.Id == FullTimeJobId).FirstOrDefault();
        }

        public IEnumerable<Job> GetJobsByName(string name, int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = this.DbSet.Count();
            return this.Get(f => f.Name == name, pageIndex, pageSize, f => f.CreatedDate, false);
        }

        //public IEnumerable<Job> GetJobsByTypeId(int Id, int pageIndex, int pageSize, out int recordCount)
        //{
        //    recordCount = this.DbSet.Count();
        //    return this.Get(f => f.Type.FullTimeJobTypeId == Id, pageIndex, pageSize, f => f.CreatedDate, false);
        //}

        public void AddCompany(Company company)
        {
            DbContext.Companys.Add(company);
            DbContext.SaveChanges();
        }
    }
}
