using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Model
{
    /// <summary>
    /// 出租、出售工程设备及小型机具
    /// </summary>
    public class Equipment : InfoEntityBase
    {
        public string Name { get; set; }    //设备名称	
        public string Model { get; set; }   //型号
        public string Condition { get; set; }    //新旧程度或出场日期
        public string Manufacturer { get; set; }    //生产厂家
        public string Location { get; set; }    //设备所在位置
        public string Price { get; set; }    //售价或租金
        public string ServiceWay { get; set; }  // 服务方式: 出售/出租
        public string Image { get; set; }    //机械图片
    }
}
