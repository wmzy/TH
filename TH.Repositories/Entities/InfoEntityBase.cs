using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TH.Repositories.Entities
{
    public abstract class InfoEntityBase
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public DateTime? CreatedDate { get; set; }   //发布时间
        public User Publisher { get; set; }     // 发布者
        public string Genre { get; set; }        // 信息类型
        
        //联系方式Contact
        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        public string QQ { get; set; }
    }
}
