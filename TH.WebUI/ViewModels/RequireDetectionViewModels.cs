using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TH.WebUI.ViewModels
{
    public class RequireDetectionIndexViewModel
    {
        public int Id { get; set; }
        [DisplayName("标题")]
        public string Title { get; set; }
        public DateTime? CreateDate { get; set; }   //发布时间
        public string Name { get; set; }    //工程项目名称	
        public string QualificationGrade { get; set; }   //需要的资质等级
        public string Item { get; set; }    //需要试验、检测的项目
        public string Contents { get; set; }    //试验、检测内容（可多选）
        public string Location { get; set; }    // 检测地址
    }

    public class RequireDetectionCreateViewModel
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
        public string Name { get; set; }    //工程项目名称	
        public string QualificationGrade { get; set; }   //需要的资质等级
        public string Item { get; set; }    //需要试验、检测的项目
        public string Contents { get; set; }    //试验、检测内容（可多选）
        public string Location { get; set; }    // 检测地址
    }

    public class RequireDetectionDetailsViewModel
    {
        public string Title { get; set; }

        [DisplayName("联系人")]
        public string ContactPerson { set; get; }    // 联系人
        public DateTime? CreateDate { get; set; }   //发布时间
        [DisplayName("联系电话")]
        public string Telephones { get; set; }      // 联系电话
        public string Name { get; set; }    //工程项目名称	
        public string QualificationGrade { get; set; }   //需要的资质等级
        public string Item { get; set; }    //需要试验、检测的项目
        public string Contents { get; set; }    //试验、检测内容（可多选）
        public string Location { get; set; }    // 检测地址
    }

    public class RequireDetectionEditViewModel
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
        [DisplayName("工程项目名称")]
        public string Name { get; set; }    //工程项目名称	
        [DisplayName("需要的资质等级")]
        public string QualificationGrade { get; set; }   //需要的资质等级
        [DisplayName("需要试验、检测的项目")]
        public string Item { get; set; }    //需要试验、检测的项目
        [DisplayName("试验、检测内容")]
        public string Contents { get; set; }    //试验、检测内容（可多选）
        [DisplayName("检测地址")]
        public string Location { get; set; }    // 检测地址
    }
}