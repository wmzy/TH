using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TH.Model
{
    /// <summary>
    /// 公司信息
    /// </summary>
    [Table("Company")]
    public class Company
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }
        public string RegistrationNumber { get; set; }  // 注册号
        public string Name { get; set; }
        public string NickName { get; set; }    // 别称
        public string LegalPerson { get; set; } // 法人代表
        public string Trade { get; set; }   // 所属行业
        public string Type { get; set; }    // 公司性质
        public int? SizeL { get; set; }  // 公司规模
        public int? SizeT { get; set; }
        public string Introduction { get; set; } // 公司简介
        public string Address { get; set; }
        public string Website { get; set; } // 网站

        public User Manager { get; set; }   // 信息管理者
        public virtual ICollection<User> Agencies { get; set; }
    }
}
