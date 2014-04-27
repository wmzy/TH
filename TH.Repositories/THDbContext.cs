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

        public DbSet<Job> Jobs { get; set; }
    }
}