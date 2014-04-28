using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Repositories.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserName { set; get; }
        public string Email { set; get; }
        public DateTime CommentDate{ set; get; }
        public string Content { set; get; }
    }
}
