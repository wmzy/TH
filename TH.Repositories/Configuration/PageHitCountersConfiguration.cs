using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Model;

namespace TH.Repositories.Configuration
{
    class PageHitCountersConfiguration : EntityTypeConfiguration<PageHitCounters>
    {
        public PageHitCountersConfiguration()
        {
            ToTable("PageHitCounterses");
            HasKey(phc => phc.Url);
            Property(phc => phc.Url).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsVariableLength();
        }
    }
}
