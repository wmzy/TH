﻿namespace TH.Model
{
    public class Machine : InfoBase
    {
        public string Name { get; set; }    //机械名称	
        public string Model { get; set; }   //型号
        public string Condition { get; set; }    //新旧程度或出场日期
        public string Manufacturer { get; set; }    //生产厂家
        public string Location { get; set; }    //机械所在位置
        public string Price { get; set; }    //售价或租金
        public string ServiceWay { get; set; }  // 服务方式: 出售/出租
        public string Image { get; set; }    //机械图片
    }
}
