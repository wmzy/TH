﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TH.Model;
using TH.Repositories.Configuration;
using System.ComponentModel.DataAnnotations.Schema;

namespace TH.Repositories
{
    public class THDbContext : IdentityDbContext<User>
    {
        public THDbContext()
            : base("THConnection")
        {
        }
        
        #region DbSet
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobHunting> JobHuntings { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ContractProject> ContractProjects { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        #endregion

        //https://github.com/rustd/AspnetIdentitySample
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();

            // Change the name of the table to be Users instead of AspNetUsers
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("Logins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("Claims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

            #region Configurations

            modelBuilder.Configurations.Add(new UserConfiguration());
            //modelBuilder.Configurations.Add(new InfoEntityBaseConfiguration());
            modelBuilder.Configurations.Add(new JobConfiguration());
            modelBuilder.Configurations.Add(new JobHuntingConfiguration());
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());

            #endregion
        }
    }
}