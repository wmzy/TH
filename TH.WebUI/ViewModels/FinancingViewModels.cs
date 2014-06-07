using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TH.WebUI.ViewModels
{
    public class FinancingIndexViewModel
    {
        public int Id { get; set; }
        [DisplayName("标题")]
        public string Title { get; set; }
        public DateTime? CreateDate { get; set; }   //发布时间
        [DisplayName("企业名称")]
        public string CompanyName { get; set; }    //企业名称
        [DisplayName("融资范围")]
        public string Range { get; set; }       //	融资范围
        [DisplayName("贷款条件")]
        public string Condition { get; set; }   // 贷款条件
        [DisplayName("贷款额度")]
        public string Quota { get; set; }       //贷款额度
        [DisplayName("利息")]
        public string Interest { get; set; }    // 利息
    }

    public class FinancingCreateViewModel
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
        public string CompanyName { get; set; }    //企业名称
        public string Range { get; set; }       //	融资范围
        public string Condition { get; set; }   // 贷款条件
        public string Quota { get; set; }       //贷款额度
        public string Interest { get; set; }    // 利息
    }

    public class FinancingDetailsViewModel
    {
        public string Title { get; set; }

        [DisplayName("联系人")]
        public string ContactPerson { set; get; }    // 联系人
        [DisplayName("联系电话")]
        public string Telephones { get; set; }      // 联系电话
        public DateTime? CreateDate { get; set; }   //发布时间
        public string CompanyName { get; set; }    //企业名称
        public string Range { get; set; }       //	融资范围
        public string Condition { get; set; }   // 贷款条件
        public string Quota { get; set; }       //贷款额度
        public string Interest { get; set; }    // 利息
    }

    public class FinancingEditViewModel
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
        [DisplayName("融资范围")]
        public string Range { get; set; }       //	融资范围
        [DisplayName("贷款条件")]
        public string Condition { get; set; }   // 贷款条件
        [DisplayName("贷款额度")]
        public string Quota { get; set; }       //贷款额度
        [DisplayName("利息")]
        public string Interest { get; set; }    // 利息
    }
}