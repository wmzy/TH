using System;

namespace TH.Model
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
