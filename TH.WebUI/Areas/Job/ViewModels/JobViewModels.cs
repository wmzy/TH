using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TH.WebUI.Areas.Job.ViewModels
{
    public class JobIndexViewModel
    {
    }

    public class JobCreateViewModel
    {
        [DisplayName("招聘单位或经营个体")]
        public string Company { set; get; }     // 招聘单位或经营个体
        [DisplayName("职位名称")]
        public string Name { get; set; }        // 职位名称
        [DisplayName("招聘人数")]
        public int? RecruitCount { get; set; }  // 招聘人数
        [DisplayName("工作地点")]
        public string Location { get; set; }    // 工作地点
        [DisplayName("学历要求")]
        public string EducationRequire { get; set; }    // 学历要求
        [DisplayName("工作年限")]
        public string WorkYears { get; set; }  // 工作年限
        [DisplayName("薪资范围")]
        public string Wage { get; set; }      // 薪资范围
        [DisplayName("工作描述")]
        public string JobDescription { get; set; }
        [DisplayName("招聘单位或个体简介")]
        public string CompanyIntroduction { set; get; } //招聘单位或个体简介
        [DisplayName("岗位要求")]
        public string Requirements { set; get; }    //岗位要求
        [DisplayName("联系方式")]
        public string Contact { set; get; }    // 联系方式
    }
}