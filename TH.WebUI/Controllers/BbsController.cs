using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity;
using TH.Model;
using TH.Services;
using TH.WebUI.ViewModels;

namespace TH.WebUI.Controllers
{
    [Authorize]
    public class BbsController : Controller
    {
        private readonly IPostService _postService;
        public BbsController(IPostService postService)
        {
            _postService = postService;
        }
        //
        // GET: /Bbs/
        [AllowAnonymous]
        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            if (pageIndex < 1 || pageSize < 0)
            {
                return HttpNotFound();
            }

            int pagerecordCount;
            var posts = _postService.Get(pageIndex, pageSize, out pagerecordCount).Project().To<PostIndexViewModel>().ToList();
            return View(posts);
        }

        //
        // GET: /Bbs/Post/5
        [AllowAnonymous]
        public ActionResult Post(int id)
        {
            var post = _postService.GetById(id);
            var postDetail = Mapper.Map<Post, PostDetailsViewModel>(post);

            return View(postDetail);
        }

        //
        // GET: /Bbs/CreatePost
        public ActionResult CreatePost()
        {
            return View();
        }

        //
        // POST: /Bbs/CreatePost
        [HttpPost]
        public ActionResult CreatePost(PostCreateViewModel model)
        {
            if (!validateHtml(model.Content))
            {
                ModelState.AddModelError("Content", "危险的标签");
                return View(model);
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var post = Mapper.Map<PostCreateViewModel, Post>(model);
                post.CreaterId = User.Identity.GetUserId();
                
                _postService.Create(post);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        //
        // GET: /Bbs/EditPost/5
        public ActionResult EditPost(int id)
        {
            var post = _postService.GetById(id);
            var postEdit = Mapper.Map<Post, PostEditViewModel>(post);
            return View(postEdit);
        }

        //
        // POST: /Bbs/EditPost/5
        [HttpPost]
        public ActionResult EditPost(PostEditViewModel model)
        {
            if (!validateHtml(model.Content))
            {
                ModelState.AddModelError("Content", "危险的标签");
                return View(model);
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var post = _postService.GetById(model.Id);
                if (post.CreaterId != User.Identity.GetUserId())
                {
                    return HttpNotFound();
                }

                Mapper.Map(model, post);
                _postService.Update(post);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        private bool validateHtml(string html)
        {
            return string.IsNullOrEmpty(html) || !html.Contains("<script");
        }

        //
        // POST: /Bbs/DeletePost/5
        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            _postService.OwnerDelete(User.Identity.GetUserId(), id);
            return null;
        }

        [HttpPost]
        public ActionResult AddComment(CommentFormViewModel model)
        {
            if (!validateHtml(model.Content))
            {
                ModelState.AddModelError("Content", "危险的标签");
                return Json(model);
            }
            if (!ModelState.IsValid)
            {
                return Json(model);
            }

            var comment = Mapper.Map<CommentFormViewModel, Comment>(model);
            comment.UserId = User.Identity.GetUserId();
            _postService.AddComment(model.PostId, comment);
            var commentViewModel = Mapper.Map<Comment, CommentViewModel>(comment);

            return Json(commentViewModel);
        }

        [HttpPost]
        public ActionResult DeleteComment(int id)
        {
            _postService.DeleteComment(User.Identity.GetUserId(), id);
            return null;
        }
    }
}
