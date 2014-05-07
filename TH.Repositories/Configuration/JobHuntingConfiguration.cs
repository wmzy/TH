using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Repositories.Entities;

namespace TH.Repositories.Configuration
{
    class JobHuntingConfiguration : EntityTypeConfiguration<JobHunting>
    {
        public JobHuntingConfiguration()
        {
            ToTable("JobHunting");
        }
    }
}
