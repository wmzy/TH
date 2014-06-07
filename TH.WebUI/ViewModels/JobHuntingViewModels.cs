using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TH.Model;

namespace TH.WebUI.ViewModels
{
    public class JobHuntingIndexViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreateDate { get; set; }   //发布时间
        public string Name { get; set; }//姓名	
        public string Nation { get; set; }//民族	
        public int? Age { get; set; }    //年龄	
        public string WorkYears { get; set; }    //工作年限	
        public string Education { get; set; }    //学历	
        public string Job { get; set; }    //求职岗位	
    }

    public class JobHuntingCreateViewModel
    {
        [DisplayName("标题")]
        [Required]
        public string Title { get; set; }

        //联系方式Contact
        [DisplayName("联系电话")]
        [Required]
        public string Telephones { get; set; }      // 联系电话';'分隔
        [DisplayName("姓名")]
        [Required]
        public string Name { get; set; }    //姓名
        [DisplayName("民族")]
        public string Nation { get; set; }  //民族
        [DisplayName("年龄")]
        public int? Age { get; set; }       //年龄
        [DisplayName("工作年限")]
        public string WorkYears { get; set; }    //工作年限
        [DisplayName("学历")]
        public string Education { get; set; }    //学历
        [DisplayName("工作经验")]
        public string WorkExperience { get; set; }    //工作经验
        [DisplayName("求职岗位")]
        public string Job { get; set; }    //求职岗位
        [DisplayName("薪资要求")]
        public string Wage { get; set; }    //薪资要求
        [DisplayName("个人简介")]
        public string Introduction { get; set; }    //个人简介
    }

    public class JobHuntingDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DisplayName("联系人")]
        public string ContactPerson { set; get; }    // 联系人
        public DateTime? CreateDate { get; set; }   //发布时间
        public User Publisher { get; set; }     // 发布者
        public string Telephones { get; set; }      // 联系电话
        public string Name { get; set; }    //姓名	
        public string Nation { get; set; }  //民族	
        public int? Age { get; set; }       //年龄	
        public string WorkYears { get; set; }     //工作年限	
        public string Education { get; set; }    //学历	
        public string WorkExperience { get; set; }    //工作经验
        public string Job { get; set; }    //求职岗位	
        public string Wage { get; set; }    //薪资要求	
        public string Introduction { get; set; }    //个人简介
    }

    public class JobHuntingEditViewModel
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("标题")]
        [Required]
        public string Title { get; set; }
        [DisplayName("联系电话")]
        [Required]
        public string Telephones { get; set; }      // 联系电话';'分隔
        [DisplayName("姓名")]
        [Required]
        public string Name { get; set; }    //姓名
        [DisplayName("民族")]
        public string Nation { get; set; }  //民族
        [DisplayName("年龄")]
        public int? Age { get; set; }       //年龄
        [DisplayName("工作年限")]
        public string WorkYears { get; set; }    //工作年限
        [DisplayName("学历")]
        public string Education { get; set; }    //学历
        [DisplayName("工作经验")]
        public string WorkExperience { get; set; }    //工作经验
        [DisplayName("求职岗位")]
        public string Job { get; set; }    //求职岗位
        [DisplayName("薪资要求")]
        public string Wage { get; set; }    //薪资要求
        [DisplayName("个人简介")]
        public string Introduction { get; set; }    //个人简介
    }
}