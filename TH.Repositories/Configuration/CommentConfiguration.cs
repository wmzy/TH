using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Model;

namespace TH.Repositories.Configuration
{
    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            ToTable("Comments");
            HasRequired(c => c.User).WithMany().HasForeignKey(c => c.UserId).WillCascadeOnDelete(false);
            HasMany(c => c.Replies).WithOptional().Map(m => m.MapKey("ReplyForId")).WillCascadeOnDelete(true);
        }
    }
}
