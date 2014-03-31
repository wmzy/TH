using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TH.WebUI.Areas.Recruitment.Models
{
    public class CompanyModel
    {
        [DisplayName("注册号")]
        public string RegistrationNumber { get; set; }  // 注册号
        [DisplayName("名称")]
        public string Name { get; set; }
        [DisplayName("别称")]
        public string NickName { get; set; }    // 别称
        [DisplayName("法人代表")]
        public string LegalPerson { get; set; } // 法人代表
        [DisplayName("所属行业")]
        public string Trade { get; set; }   // 所属行业
        [DisplayName("公司性质")]
        public string Type { get; set; }    // 公司性质
        [DisplayName("公司规模")]
        public int? SizeL { get; set; }  // 公司规模
        [DisplayName("公司规模")]
        public int? SizeT { get; set; }
        [DisplayName("公司简介")]
        public string Introduction { get; set; } // 公司简介
        [DisplayName("地址")]
        public string Address { get; set; }
        [DisplayName("网站")]
        public string Website { get; set; } // 网站
    }
}