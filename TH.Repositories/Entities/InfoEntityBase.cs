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
        
        //联系方式Contact
        public string Telephones { get; set; }      // 联系电话';'分隔
        public string ContactPerson { get; set; } // 联系人
        public int Views { set; get; }  //浏览量
    }
}
