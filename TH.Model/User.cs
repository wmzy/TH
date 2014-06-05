using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TH.Model
{
    public class User : IdentityUser
    {
        public string RealName { get; set; }
        public string Nickname { get; set; }

        public string QQ { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public string PhotoURL { get; set; }
        public DateTime? Birthday { get; set; }
        public string Sex { get; set; }
        public string AboutMe { get; set; }
        public DateTime CreateDate { get; set; }
        public string City { get; set; }
        public int WealthValue { get; set; }    // 财富值

        #region PublishedInfos
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<JobHunting> JobHuntings { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<ContractProject> ContractProjects { get; set; }
        #endregion

        public User()
        {
            CreateDate = DateTime.Now;
            WealthValue = 100;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
