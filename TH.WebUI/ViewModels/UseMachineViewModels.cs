using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TH.WebUI.ViewModels
{
    public class UseMachineIndexViewModel
    {
        public int Id { get; set; }
        [DisplayName("标题")]
        public string Title { get; set; }
        public DateTime? CreateDate { get; set; }   //发布时间
        public string Name { get; set; }    //机械名称	
        public string Model { get; set; }   //型号
        public string Condition { get; set; }    //新旧程度或出场日期
        public string Location { get; set; }    //机械使用位置
        public string Duration { get; set; }     // 使用时长
        public string UseWay { get; set; }  // 使用方式: 购买/租用
    }

    public class UseMachineCreateViewModel
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
        [DisplayName("新旧程度或出厂日期")]
        public string Condition { get; set; }    //新旧程度或出厂日期
        [DisplayName("机械使用位置")]
        public string Location { get; set; }    //机械使用位置
        [DisplayName("使用时长")]
        public string Duration { get; set; }     // 使用时长
        [DisplayName("使用方式")]
        public string UseWay { get; set; }  // 使用方式: 购买/租用
    }

    public class UseMachineDetailsViewModel
    {
        public string Title { get; set; }

        [DisplayName("联系人")]
        public string ContactPerson { set; get; }    // 联系人
        [DisplayName("联系电话")]
        public string Telephones { get; set; }      // 联系电话
        public string Name { get; set; }    //机械名称	
        public string Model { get; set; }   //型号
        public string Condition { get; set; }    //新旧程度或出场日期
        public string Location { get; set; }    //机械使用位置
        public string Duration { get; set; }     // 使用时长
        public string UseWay { get; set; }  // 使用方式: 购买/租用
        public DateTime? CreateDate { get; set; }   //发布时间
    }

    public class UseMachineEditViewModel
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
        [DisplayName("机械使用位置")]
        public string Location { get; set; }    //机械使用位置
        [DisplayName("使用时长")]
        public string Duration { get; set; }     // 使用时长
        [DisplayName("使用方式")]
        public string UseWay { get; set; }  // 使用方式: 购买/租用
    }
}