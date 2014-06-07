using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TH.WebUI.ViewModels
{
    public class MachineIndexViewModel
    {
        public int Id { get; set; }
        [DisplayName("标题")]
        public string Title { get; set; }
        public DateTime? CreateDate { get; set; }   //发布时间
        public string Name { get; set; }    //机械名称	
        public string Model { get; set; }   //型号
        public string Condition { get; set; }    //新旧程度或出场日期
        public string Location { get; set; }    //机械所在位置
        public string ServiceWay { get; set; }  // 服务方式: 出售/出租
    }

    public class MachineCreateViewModel
    {
        [DisplayName("标题")]
        [Required]
        public string Title { get; set; }
        [DisplayName("联系人")]
        [Required]
        public string ContactPerson { set; get; }    // 联系人
        [DisplayName("联系电话")]
        [Required]
        public string Telephones { get; set; }      // 联系电话';'分隔
        [DisplayName("机械名称")]
        public string Name { get; set; }    //机械名称	
        [DisplayName("型号")]
        public string Model { get; set; }   //型号
        [DisplayName("新旧程度或出场日期")]
        public string Condition { get; set; }    //新旧程度或出场日期
        [DisplayName("生产厂家")]
        public string Manufacturer { get; set; }    //生产厂家
        [DisplayName("机械所在位置")]
        public string Location { get; set; }    //机械所在位置
        [DisplayName("售价或租金")]
        public string Price { get; set; }    //售价或租金
        [DisplayName("服务方式")]
        public string ServiceWay { get; set; }  // 服务方式: 出售/出租
        [DisplayName("机械图片")]
        public string Image { get; set; }    //机械图片
    }

    public class MachineDetailsViewModel
    {
        public string Title { get; set; }

        [DisplayName("联系人")]
        public string ContactPerson { set; get; }    // 联系人
        [DisplayName("联系电话")]
        public string Telephones { get; set; }      // 联系电话
        public DateTime? CreateDate { get; set; }   //发布时间
        public string Name { get; set; }    //机械名称	
        public string Model { get; set; }   //型号
        public string Condition { get; set; }    //新旧程度或出场日期
        public string Manufacturer { get; set; }    //生产厂家
        public string Location { get; set; }    //机械所在位置
        public string Price { get; set; }    //售价或租金
        public string ServiceWay { get; set; }  // 服务方式: 出售/出租
        public string Image { get; set; }    //机械图片
    }

    public class MachineEditViewModel
    {
        [UIHint("HiddenInput")]
        [Required]
        public int Id { get; set; }

        [DisplayName("标题")]
        [Required]
        public string Title { get; set; }
        [DisplayName("联系人")]
        [Required]
        public string ContactPerson { set; get; }    // 联系人
        [DisplayName("联系电话")]
        [Required]
        public string Telephones { get; set; }      // 联系电话';'分隔
        [DisplayName("机械名称")]
        public string Name { get; set; }    //机械名称	
        [DisplayName("型号")]
        public string Model { get; set; }   //型号
        [DisplayName("新旧程度或出场日期")]
        public string Condition { get; set; }    //新旧程度或出场日期
        [DisplayName("生产厂家")]
        public string Manufacturer { get; set; }    //生产厂家
        [DisplayName("机械所在位置")]
        public string Location { get; set; }    //机械所在位置
        [DisplayName("售价或租金")]
        public string Price { get; set; }    //售价或租金
        [DisplayName("服务方式")]
        public string ServiceWay { get; set; }  // 服务方式: 出售/出租
        [DisplayName("机械图片")]
        public string Image { get; set; }    //机械图片
    }
}