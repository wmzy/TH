using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TH.WebUI.ViewModels
{
    public class BuyBuildingMaterialIndexViewModel
    {
        public int Id { get; set; }
        [DisplayName("标题")]
        public string Title { get; set; }
        public DateTime? CreateDate { get; set; }   //发布时间
        public string Name { get; set; }    //建材名称
        public string Model { get; set; }   //规格、型号
        public string ForProject { get; set; }  // 使用项目名称
        public string Location { get; set; }    //建材位置
    }

    public class BuyBuildingMaterialCreateViewModel
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
        [DisplayName("建材名称")]
        public string Name { get; set; }    //建材名称
        [DisplayName("规格、型号")]
        public string Model { get; set; }   //规格、型号
        [DisplayName("使用项目名称")]
        public string ForProject { get; set; }  // 使用项目名称
        [DisplayName("建材位置")]
        public string Location { get; set; }    //建材位置
    }

    public class BuyBuildingMaterialDetailsViewModel
    {
        public string Title { get; set; }

        [DisplayName("联系人")]
        public string ContactPerson { set; get; }    // 联系人
        [DisplayName("联系电话")]
        public string Telephones { get; set; }      // 联系电话
        public DateTime? CreateDate { get; set; }   //发布时间
        public string Name { get; set; }    //建材名称
        public string Model { get; set; }   //规格、型号
        public string ForProject { get; set; }  // 使用项目名称
        public string Location { get; set; }    //建材位置
    }

    public class BuyBuildingMaterialEditViewModel
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
        [DisplayName("建材名称")]
        public string Name { get; set; }    //建材名称
        [DisplayName("规格、型号")]
        public string Model { get; set; }   //规格、型号
        [DisplayName("使用项目名称")]
        public string ForProject { get; set; }  // 使用项目名称
        [DisplayName("建材位置")]
        public string Location { get; set; }    //建材位置
    }
}