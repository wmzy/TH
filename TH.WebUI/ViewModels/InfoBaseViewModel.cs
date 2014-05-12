using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TH.WebUI.ViewModels
{
    public class InfoBaseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }   //发布时间
        public DateTime? ValidDate { get; set; }     // 有效期

        //联系方式Contact
        public string Telephones { get; set; }      // 联系电话';'分隔
        public string ContactPerson { get; set; }   // 联系人
        public int Views { set; get; }  //浏览量
    }
}