using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TH.Repositories.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace TH.Repositories
{
    public class THDbContext : IdentityDbContext<User>
    {
        public THDbContext()
            : base("THConnection")
        {
        }

        //https://github.com/rustd/AspnetIdentitySample
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Change the name of the table to be Users instead of AspNetUsers
            modelBuilder.Entity<IdentityUser>()
                .ToTable("Users");
            modelBuilder.Entity<User>()
                .ToTable("Users");
        }


        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobHunting> JobHuntings { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ContractProject> ContractProjects { get; set; }
    }
}