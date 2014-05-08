using System.Collections.Generic;

namespace TH.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { set; get; }
        public User Creater { set; get; }
        public string Content { set; get; }
        public int Views { set; get; }  //浏览量
        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
