using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Model
{
    public class UseEquipment : InfoEntityBase
    {
        public string Name { get; set; }    //机械名称	
        public string Model { get; set; }   //型号
        public string Condition { get; set; }    //新旧程度或出场日期
        public string Location { get; set; }    //机械使用位置
        public string Duration { get; set; }     // 使用时长
        public string UseWay { get; set; }  // 使用方式: 购买/租用
    }
}
