using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Model
{
    /// <summary>
    /// 试验、检测
    /// </summary>
    public class Detection : InfoEntityBase
    {
        public string Name { get; set; }    //资质单位名称
        public string QualificationGrade { get; set; }   //资质等级
        public string Item { get; set; }    //试验、检测项目
        public string Contents { get; set; }    //试验、检测内容（可多选）
        public string Price { get; set; }       //收费标准
    }
}
