using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TH.WebUI.ViewModels
{
    public class CredentialIndexViewModel
    {
        public int Id { get; set; }
        [DisplayName("标题")]
        public string Title { get; set; }
        public DateTime? CreateDate { get; set; }   //发布时间
        public string CompanyName { get; set; }    //企业名称
        public string Type { get; set; }   //所需证件类型
        public string Major { get; set; }    // 专业
        public string Class { get; set; }    // 证件类别
        public string Price { get; set; }       //价格
    }

    public class CredentialCreateViewModel
    {
        [DisplayName("标题")]
        [Required]
        public string Title { get; set; }
        [DisplayName("联系人")]
        [Required]
        public string ContactPerson { set; get; }    // 联系人
        [DisplayName("联系电话")]
        [Required]
        public string Telephones { get; set; }      // 联系电话';'分隔
        [DisplayName("企业名称")]
        public string CompanyName { get; set; }    //企业名称
        [DisplayName("所需证件类型")]
        public string Type { get; set; }   //所需证件类型
        [DisplayName("专业")]
        public string Major { get; set; }    // 专业
        [DisplayName("证件类别")]
        public string Class { get; set; }    // 证件类别
        [DisplayName("价格")]
        public string Price { get; set; }       //价格
    }

    public class CredentialDetailsViewModel
    {
        public string Title { get; set; }

        [DisplayName("联系人")]
        public string ContactPerson { set; get; }    // 联系人
        [DisplayName("联系电话")]
        public string Telephones { get; set; }      // 联系电话
        public DateTime? CreateDate { get; set; }   //发布时间
        public string CompanyName { get; set; }    //企业名称
        public string Type { get; set; }   //所需证件类型
        public string Major { get; set; }    // 专业
        public string Class { get; set; }    // 证件类别
        public string Price { get; set; }       //价格
    }

    public class CredentialEditViewModel
    {
        [UIHint("HiddenInput")]
        [Required]
        public int Id { get; set; }

        [DisplayName("标题")]
        [Required]
        public string Title { get; set; }
        [DisplayName("联系人")]
        [Required]
        public string ContactPerson { set; get; }    // 联系人
        [DisplayName("联系电话")]
        [Required]
        public string Telephones { get; set; }      // 联系电话';'分隔
        [DisplayName("企业名称")]
        public string CompanyName { get; set; }    //企业名称
        [DisplayName("所需证件类型")]
        public string Type { get; set; }   //所需证件类型
        [DisplayName("专业")]
        public string Major { get; set; }    // 专业
        [DisplayName("证件类别")]
        public string Class { get; set; }    // 证件类别
        [DisplayName("价格")]
        public string Price { get; set; }       //价格
    }
}