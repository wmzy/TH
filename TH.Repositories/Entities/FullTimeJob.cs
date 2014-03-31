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
    [Table("FullTimeJob")]
    public class FullTimeJob : InfoEntityBase
    {
        public string Name { get; set; }    // 职位名称
        public FullTimeJobType Type { get; set; }    // 职位类型
        public int WageL { get; set; }      // 薪资范围
        public int WageT { get; set; }
        
        public string JobDescription { get; set; }
        public bool? SexRequire { get; set; }
        public string EducationRequire { get; set; }    // 学历要求
        public int? WorkYearsL { get; set; }  // 工作年限
        public int? WorkYearsT { get; set; }
        public int RecruitCount { get; set; } // 招聘人数
        public Company Company { set; get; }
        public User Publisher { set; get; } // 发布者
        public string Tags { set; get; }    // 标签
    }
}
