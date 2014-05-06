using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Repositories.Entities
{
    /// <summary>
    /// 工程招标或发包信息
    /// </summary>
    [Table("Project")]
    public class Project : InfoEntityBase
    {
        public string Company { set; get; }     // 企业或经营个体
        public string ProjectName { get; set; } // 项目名称
        public string Content { set; get; }     //招标或发包内容
        public DateTime? StartTime { set; get; } //工程开始时间
        public int TimeLimit { set; get; }      //工程期限，单位：月
        public string Require { set; get; }     //要求
    }
}
