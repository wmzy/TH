using System;
using System.Collections.Generic;

namespace TH.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // public string Author { set; get; }
        public string CreaterId { get; set; }
        public User Creater { set; get; }
        public DateTime CreateTime { get; set; }
        public string Content { set; get; }
        public int Views { set; get; }  //浏览量
        public virtual ICollection<Comment> Comments { get; set; }

        public Post()
        {
            CreateTime = DateTime.Now;
            Views = 0;
        }
    }
}
