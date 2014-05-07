using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Repositories.Entities;

namespace TH.Repositories.Configuration
{
    class JobConfiguration : EntityTypeConfiguration<Job>
    {
        public JobConfiguration()
        {
            ToTable("Job");
        }
    }
}
