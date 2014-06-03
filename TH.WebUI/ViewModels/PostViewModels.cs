using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH.Model;

namespace TH.WebUI.ViewModels
{
    public class PostIndexViewModel
    {
        public int Id { get; set; }
        [DisplayName("标题")]
        public string Title { get; set; }
        public DateTime? CreateDate { get; set; }
    }

    public class PostCreateViewModel
    {
        [Required]
        [DisplayName("标题")]
        public string Title { get; set; }
        [Required]
        [DisplayName("内容")]
        [AllowHtml]
        [UIHint("MultilineText")]
        public string Content { set; get; }
    }

    public class PostDetailsViewModel
    {
        [UIHint("HiddenInput")]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { set; get; }
        public User Creater { set; get; }
        public DateTime CreateTime { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }

    public class PostEditViewModel
    {
        [UIHint("HiddenInput")]
        [Required]
        public int Id { get; set; }

        [DisplayName("标题")]
        [Required]
        public string Title { get; set; }
        [Required]
        [DisplayName("内容")]
        [AllowHtml]
        [UIHint("MultilineText")]
        public string Content { set; get; }
    }

    public class CommentViewModel
    {
        public int Id { get; set; }
        public string UserName { set; get; }
        public DateTime CommentTime { set; get; }
        public string Content { get; set; }
    }
    public class CommentFormViewModel
    {
        public int PostId { get; set; }
        [AllowHtml]
        public string Content { get; set; }
    }
}