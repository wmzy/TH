using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Repositories.Entities
{
    public class JobHunting : InfoEntityBase
    {
        public string Name { get; set; }//姓名	
        public string Nation { get; set; }//民族	
        public int Age { get; set; }    //年龄	
        public int WorkYears { get; set; }    //工作年限	
        public string Education { get; set; }    //学历	
        public string WorkExperience { get; set; }    //工作经验	
        public string Job { get; set; }    //求职岗位	
        public string Wage { get; set; }    //薪资要求	
        public string Introduction { get; set; }    //个人简介
    }
}
