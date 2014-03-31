using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TH.Repositories.Entities
{
    /// <summary>
    /// 全职招聘
    /// </summary>
    [Table("Job")]
    public class Job : InfoEntityBase
    {
        
        public string Company { set; get; }     // 招聘单位或经营个体
        public string Name { get; set; }        // 职位名称
        public int? RecruitCount { get; set; }  // 招聘人数
        public string Location { get; set; }    // 工作地点
        public string EducationRequire { get; set; }    // 学历要求
        public int WageL { get; set; }      // 薪资范围
        public int WageT { get; set; }
        
        public string JobDescription { get; set; }
        public int? WorkYearsL { get; set; }  // 工作年限
        public int? WorkYearsT { get; set; }
        public string CompanyIntroduction { set; get; } //招聘单位或个体简介
        public string Requirements { set; get; }    //岗位要求
    }
}
