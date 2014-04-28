using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Repositories.Entities
{
    public class ContractProject : InfoEntityBase
    {
        public string Company { set; get; }     // 企业或经营个体
        public string Content { set; get; }     //承揽工程内容
        public string Introduction { set; get; }//企业或个人简介	
        public int ConstructionExperience { set; get; } //施工经验	
        public string Performance { set; get; }     //以往业绩
    }
}
