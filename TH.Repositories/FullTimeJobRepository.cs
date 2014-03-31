using TH.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Repositories
{
    public class FullTimeJobRepository : MySameCityRepository<FullTimeJob>, IFullTimeJobRepository
    {
        public FullTimeJobRepository(THDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEnumerable<FullTimeJob> GetFullTimeJobs(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = this.DbSet.Count();
            return this.Get(f => true, pageIndex, pageSize, f => f.CreatedDate, false);
        }

        public FullTimeJob GetFullTimeJob(int FullTimeJobId)
        {
            return this.Get(f => f.Id == FullTimeJobId).FirstOrDefault();
        }

        public IEnumerable<FullTimeJob> GetFullTimeJobsByName(string name, int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = this.DbSet.Count();
            return this.Get(f => f.Name == name, pageIndex, pageSize, f => f.CreatedDate, false);
        }

        public IEnumerable<FullTimeJob> GetFullTimeJobsByTrade(string trade, int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = this.DbSet.Count();
            return this.Get(f => f.Company.Trade == trade, pageIndex, pageSize, f => f.CreatedDate, false);
        }

        public IEnumerable<FullTimeJobType> GetTypes()
        {
            return this.DbContext.FullTimeJobTypes.ToArray();
        }

        public IEnumerable<FullTimeJob> GetFullTimeJobsByType(string type, int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = this.DbSet.Count();
            return this.Get(f => f.Company.Type == type, pageIndex, pageSize, f => f.CreatedDate, false);
        }

        public IEnumerable<FullTimeJob> GetFullTimeJobsByTag(string tag, int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = this.DbSet.Count();
            return this.Get(f => f.Tags.Contains(tag), pageIndex, pageSize, f => f.CreatedDate, false);
        }

        public IEnumerable<FullTimeJob> GetFullTimeJobsByTypeId(int Id, int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = this.DbSet.Count();
            return this.Get(f => f.Type.FullTimeJobTypeId == Id, pageIndex, pageSize, f => f.CreatedDate, false);
        }

        public void AddCompany(Company company)
        {
            DbContext.Companys.Add(company);
            DbContext.SaveChanges();
        }
    }
}
