using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TH.Repositories.Entities
{
    public class User : IdentityUser
    {
        public string RealName { get; set; }
        public string Nickname { get; set; }

        public string QQ { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public string PhotoURL { get; set; }
        public DateTime? Birthday { get; set; }
        public string Sex { get; set; }
        public string AboutMe { get; set; }
        public DateTime CreateDate { get; set; }
        public string City { get; set; }

        public User()
        {
            CreateDate = DateTime.Now;
        }
    }
}
