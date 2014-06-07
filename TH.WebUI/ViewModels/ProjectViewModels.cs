using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TH.WebUI.ViewModels
{
    public class ProjectIndexViewModel
    {
        public int Id { get; set; }
        [DisplayName("标题")]
        public string Title { get; set; }
        public DateTime? CreateDate { get; set; }   //发布时间
        public string Company { set; get; }     // 企业或经营个体
        public string ProjectName { get; set; } // 项目名称
        public string Content { set; get; }     //招标或发包内容
        public DateTime? StartTime { set; get; } //工程开始时间
        public int TimeLimit { set; get; }      //工程期限，单位：月
    }
    public class ProjectCreateViewModel
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
        [DisplayName("企业或经营个体")]
        public string Company { set; get; }     // 企业或经营个体
        [DisplayName("项目名称")]
        public string ProjectName { get; set; } // 项目名称
        [DisplayName("招标或发包内容")]
        public string Content { set; get; }     //招标或发包内容
        [DisplayName("工程开始时间")]
        public DateTime? StartTime { set; get; } //工程开始时间
        [DisplayName("工程期限")]
        public int TimeLimit { set; get; }      //工程期限，单位：月
        [DisplayName("要求")]
        public string Require { set; get; }     //要求
    }
    public class ProjectDetailsViewModel
    {
        public string Title { get; set; }

        [DisplayName("联系人")]
        public string ContactPerson { set; get; }    // 联系人
        [DisplayName("联系电话")]
        public string Telephones { get; set; }      // 联系电话
        public DateTime? CreateDate { get; set; }   //发布时间
        public string Company { set; get; }     // 企业或经营个体
        public string ProjectName { get; set; } // 项目名称
        public string Content { set; get; }     //招标或发包内容
        public DateTime? StartTime { set; get; } //工程开始时间
        public int TimeLimit { set; get; }      //工程期限，单位：月
        public string Require { set; get; }     //要求
    }

    public class ProjectEditViewModel
    {
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
        [DisplayName("企业或经营个体")]
        public string Company { set; get; }     // 企业或经营个体
        [DisplayName("项目名称")]
        public string ProjectName { get; set; } // 项目名称
        [DisplayName("招标或发包内容")]
        public string Content { set; get; }     //招标或发包内容
        [DisplayName("工程开始时间")]
        public DateTime? StartTime { set; get; } //工程开始时间
        [DisplayName("工程期限")]
        public int TimeLimit { set; get; }      //工程期限，单位：月
        [DisplayName("要求")]
        public string Require { set; get; }     //要求
    }
}