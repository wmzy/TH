using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Model
{
    /// <summary>
    /// 出售建筑材料
    /// </summary>
    public class BuildingMaterial : InfoEntityBase
    {
        public string Name { get; set; }    //建材名称	
        public string Model { get; set; }   //规格、型号
        public string Manufacturer { get; set; }    //生产厂家
        public string Location { get; set; }    //经销厂址
        public string Price { get; set; }    //价格
        public string Image { get; set; }    //机械图片
    }
}
