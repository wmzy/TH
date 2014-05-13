using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Model;

namespace TH.Repositories.Configuration
{
    class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            ToTable("Posts");
            HasMany(p => p.Comments).WithOptional().Map(m => m.MapKey("PostId")).WillCascadeOnDelete(true);
        }
    }
}
