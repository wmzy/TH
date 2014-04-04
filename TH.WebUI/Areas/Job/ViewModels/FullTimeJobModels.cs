using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySameCity.Repositories.Entities;
using System.ComponentModel.DataAnnotations;

namespace MySameCity.WebUI.Areas.Recruitment.Models
{
    public class FullTimeJobModel
    {
        [Required(ErrorMessage = "标题必填")]
        [Display(Name = "标题")]
        public string Title { get; set; }    // 招聘信息标题
        [Display(Name = "职位")]
        public string Name { get; set; }    // 职位名称
        [Display(Name = "城市")]
        public int CityId { get; set; }
        [Display(Name = "区域")]
        public int RegionId { get; set; }
        [Display(Name = "工作类型")]
        public int TypeId { get; set; }    // 职位类型
        [Display(Name = "薪资下限")]
        public int WageL { get; set; }      // 薪资范围
        [Display(Name = "薪资上限")]
        public int WageT { get; set; }

        [Display(Name = "描述")]
        public string JobDescription { get; set; }
        [Display(Name = "性别")]
        public bool SexRequire { get; set; }
        [Display(Name = "教育背景")]
        public string EducationRequire { get; set; }    // 学历要求
        [Display(Name = "工作年限")]
        public int WorkYearsL { get; set; }  // 工作年限
        [Display(Name = "工作年限上限")]
        public int WorkYearsT { get; set; }
        [Display(Name = "招聘人数")]
        public int RecruitCount { get; set; } // 招聘人数
        [Display(Name = "公司ID")]
        public int CompanyId { set; get; }
        [Display(Name = "标签")]
        public int TagId { set; get; }    // 标签
    }
}