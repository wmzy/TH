using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Model;

namespace TH.Repositories.Configuration
{
    class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");
            Property(u => u.City).HasMaxLength(80);
            Property(u => u.PhotoURL).IsFixedLength().HasMaxLength(256);
            HasMany(u => u.Jobs).WithOptional().HasForeignKey(j => j.PublisherId).WillCascadeOnDelete(false);
        }
    }
}
