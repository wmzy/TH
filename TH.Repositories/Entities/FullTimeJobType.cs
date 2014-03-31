using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TH.Repositories.Entities
{
    /// <summary>
    /// 职位类型
    /// </summary>
    [Table("FullTimeJobType")]
    public class FullTimeJobType
    {
        public int FullTimeJobTypeId { get; set; }
        public string FullTimeJobTypeName { get; set; }
    }
}
