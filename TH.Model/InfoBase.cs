using System;
namespace TH.Model
{
    public abstract class InfoBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public DateTime CreatedDate { get; set; }   //发布时间
        public string PublisherId { get; set; }
        public User Publisher { get; set; }     // 发布者
        public DateTime? ValidDate { get; set; }     // 有效期

        //联系方式Contact
        public string Telephones { get; set; }      // 联系电话';'分隔
        public string ContactPerson { get; set; }   // 联系人
        //public int Views { set; get; }  //浏览量

        protected InfoBase()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
