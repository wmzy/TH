using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TH.WebUI.ViewModels
{
    public class ContractProjectIndexViewModel
    {
        public int Id { get; set; }
        [DisplayName("标题")]
        public string Title { get; set; }
        public DateTime? CreateDate { get; set; }   //发布时间
        public string Company { set; get; }     // 企业或经营个体
        public string Content { set; get; }     //承揽工程内容	
        public int ConstructionExperience { set; get; } //施工经验
    }
    public class ContractProjectCreateViewModel
    {
        [DisplayName("标题")]
        [Required(ErrorMessage = "*")]
        public string Title { get; set; }

        //联系方式Contact
        [DisplayName("联系电话';'分隔")]
        public string Telephones { get; set; }      // 联系电话';'分隔
        [DisplayName("联系人")]
        public string ContactPerson { get; set; }   // 联系人

        [DisplayName("企业或经营个体")]
        public string Company { set; get; }     // 企业或经营个体
        [DisplayName("承揽工程内容")]
        public string Content { set; get; }     //承揽工程内容
        [DisplayName("企业或个人简介")]
        public string Introduction { set; get; }//企业或个人简介
        [DisplayName("施工经验")]
        public int ConstructionExperience { set; get; } //施工经验
        [DisplayName("以往业绩")]
        public string Performance { set; get; }     //以往业绩
    }

    public class ContractProjectDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }   //发布时间

        //联系方式Contact
        public string Telephones { get; set; }      // 联系电话';'分隔
        public string ContactPerson { get; set; }   // 联系人
        public string Company { set; get; }     // 企业或经营个体
        public string Content { set; get; }     //承揽工程内容
        public string Introduction { set; get; }//企业或个人简介
        public int ConstructionExperience { set; get; } //施工经验
        public string Performance { set; get; }     //以往业绩
    }

    public class ContractProjectEditViewModel
    {
        [UIHint("HiddenInput")]
        [Required]
        public int Id { get; set; }
        [DisplayName("标题")]
        [Required]
        public string Title { get; set; }
        [DisplayName("联系人")]
        public string ContactPerson { set; get; }    // 联系人
        [DisplayName("联系电话")]
        public string Telephones { get; set; }      // 联系电话
        [DisplayName("企业或经营个体")]
        public string Company { set; get; }     // 企业或经营个体
        [DisplayName("承揽工程内容")]
        public string Content { set; get; }     //承揽工程内容
        [DisplayName("企业或个人简介")]
        public string Introduction { set; get; }//企业或个人简介	
        [DisplayName("施工经验")]
        public int ConstructionExperience { set; get; } //施工经验	
        [DisplayName("以往业绩")]
        public string Performance { set; get; }     //以往业绩
    }
}