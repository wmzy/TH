using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Model
{
    public class BuyBuildingMaterial : InfoEntityBase
    {
        public string Name { get; set; }    //建材名称
        public string Model { get; set; }   //规格、型号
        public string ForProject { get; set; }  // 使用项目名称
        public string Location { get; set; }    //建材位置
    }
}
