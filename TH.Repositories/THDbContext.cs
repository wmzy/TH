using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using TH.Repositories.Entities;

namespace TH.Repositories
{
    public class THDbContext: DbContext
    {
        public THDbContext()
            : base("name=TH")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Job> FullTimeJobs { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Genre> Genres { get; set; }

        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderLine> OrderLines { get; set; }
        //public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.CompaniesAgented)
                .WithMany(c => c.Agencies)
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("CompanyId");
                    m.ToTable("User_Company");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}