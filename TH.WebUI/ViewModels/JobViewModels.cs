using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TH.WebUI.ViewModels
{
    public class JobIndexViewModel
    {
        public int Id { get; set; }
        [DisplayName("标题")]
        public string Title { get; set; }
        [DisplayName("招聘单位或经营个体")]
        public string Company { set; get; }     // 招聘单位或经营个体
        [DisplayName("职位名称")]
        public string Name { get; set; }        // 职位名称
        [DisplayName("招聘人数")]
        public int? RecruitCount { get; set; }  // 招聘人数
        [DisplayName("工作地点")]
        public string Location { get; set; }    // 工作地点
        [DisplayName("薪资范围")]
        public string Wage { get; set; }      // 薪资范围
        public DateTime? CreatedDate { get; set; }   //发布时间
    }

    public class JobCreateViewModel
    {
        [DisplayName("标题")]
        [Required]
        public string Title { get; set; }
        [DisplayName("招聘单位或经营个体")]
        [Required]
        public string Company { set; get; }     // 招聘单位或经营个体
        [UIHint("ChosenJobName")]
        [DisplayName("职位名称")]
        public string Name { get; set; }        // 职位名称
        [DisplayName("招聘人数")]
        [Range(1, 100)]
        public int? RecruitCount { get; set; }  // 招聘人数
        [UIHint("ChosenLocation")]
        [DisplayName("工作地点")]
        public string Location { get; set; }    // 工作地点
        [UIHint("ChosenEducationRequire")]
        [DisplayName("学历要求")]
        public string EducationRequire { get; set; }    // 学历要求
        [UIHint("ChosenWorkYears")]
        [DisplayName("工作年限")]
        public string WorkYears { get; set; }  // 工作年限
        [UIHint("ChosenWage")]
        [DisplayName("薪资范围")]
        public string Wage { get; set; }      // 薪资范围
        [MaxLength(500)]
        [DisplayName("职位描述")]
        public string JobDescription { get; set; }
        [MaxLength(500)]
        [UIHint("MultilineText")]
        [DisplayName("招聘单位或个体简介")]
        public string CompanyIntroduction { set; get; } //招聘单位或个体简介
        [UIHint("MultilineText")]
        [MaxLength(300)]
        [DisplayName("岗位要求")]
        public string Requirements { set; get; }    //岗位要求
        [DisplayName("联系人")]
        [Required]
        public string ContactPerson { set; get; }    // 联系人
        [DisplayName("联系电话")]
        [Required]
        public string Telephones { get; set; }      // 联系电话';'分隔
    }

    public class JobDetailsViewModel
    {
        public string Title { get; set; }
        public string Company { set; get; }     // 招聘单位或经营个体
        public string Name { get; set; }        // 职位名称
        public int? RecruitCount { get; set; }  // 招聘人数
        public string Location { get; set; }    // 工作地点
        public string EducationRequire { get; set; }    // 学历要求
        public string WorkYears { get; set; }  // 工作年限
        public string Wage { get; set; }      // 薪资范围
        public string JobDescription { get; set; }
        public string CompanyIntroduction { set; get; } //招聘单位或个体简介
        public string Requirements { set; get; }    //岗位要求
        public string ContactPerson { set; get; }    // 联系人
        public string Telephones { get; set; }      // 联系电话';'分隔
    }
}