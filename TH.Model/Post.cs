using System.Collections.Generic;

namespace TH.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // public string Author { set; get; }
        public int CreaterId { get; set; }
        public User Creater { set; get; }
        public string Content { set; get; }
        public int Views { set; get; }  //浏览量
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
