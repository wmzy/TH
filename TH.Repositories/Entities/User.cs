using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TH.Repositories.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Nickname { get; set; }

        public string QQ { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }

        public string PhotoURL { get; set; }
        public DateTime? Birthday { get; set; }
        public string Sex { get; set; }
        public string AboutMe { get; set; }
        public DateTime? CreateDate { get; set; }

        public int? CountryId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }

        public virtual ICollection<Company> CompaniesAgented { get; set; } // 代理的公司
    }
}
