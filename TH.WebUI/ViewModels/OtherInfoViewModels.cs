using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TH.WebUI.ViewModels
{
    public class OtherInfoIndexViewModel
    {
        public int Id { get; set; }
        [DisplayName("标题")]
        public string Title { get; set; }
        public DateTime? CreateDate { get; set; }   //发布时间
        public string CompanyName { get; set; }    //企业或个人名称
        public string Content { set; get; }     //	供求内容
    }

    public class OtherInfoCreateViewModel
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
        [DisplayName("企业或个人名称")]
        public string CompanyName { get; set; }    //企业或个人名称
        [DisplayName("供求内容")]
        public string Content { set; get; }     //	供求内容
        [DisplayName("价格")]
        public string Price { get; set; }       //价格
    }

    public class OtherInfoDetailsViewModel
    {
        public string Title { get; set; }

        [DisplayName("联系人")]
        public string ContactPerson { set; get; }    // 联系人
        [DisplayName("联系电话")]
        public string Telephones { get; set; }      // 联系电话
        public DateTime? CreateDate { get; set; }   //发布时间
        public string CompanyName { get; set; }    //企业或个人名称
        public string Content { set; get; }     //	供求内容
        public string Price { get; set; }       //价格
    }

    public class OtherInfoEditViewModel
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
        [DisplayName("企业或个人名称")]
        public string CompanyName { get; set; }    //企业或个人名称
        [DisplayName("供求内容")]
        public string Content { set; get; }     //	供求内容
        [DisplayName("价格")]
        public string Price { get; set; }       //价格
    }
}