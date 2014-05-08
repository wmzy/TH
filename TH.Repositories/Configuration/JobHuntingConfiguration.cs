using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Model;

namespace TH.Repositories.Configuration
{
    class JobHuntingConfiguration : EntityTypeConfiguration<JobHunting>
    {
        public JobHuntingConfiguration()
        {
            ToTable("JobHuntings");
            Property(j => j.Title).HasMaxLength(40).IsFixedLength();
        }
    }
}
