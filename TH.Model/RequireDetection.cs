using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Model
{
    public class RequireDetection : InfoEntityBase
    {
        public string Name { get; set; }    //工程项目名称	
        public string QualificationGrade { get; set; }   //需要的资质等级
        public string Item { get; set; }    //需要试验、检测的项目
        public string Contents { get; set; }    //试验、检测内容（可多选）
        public string Location { get; set; }    // 检测地址
    }
}
