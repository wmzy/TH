using System;
using System.Collections.Generic;

namespace TH.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { set; get; }
        public DateTime CommentTime{ set; get; }
        public string Content { set; get; }
        public ICollection<Comment> Replies { get; set; }

        public Comment()
        {
            CommentTime = DateTime.Now;
        }
    }
}
