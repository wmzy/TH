using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TH.Model;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface IPostService : IService
    {
        IQueryable<Post> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<Post> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount);
        Post GetById(int id);
        IQueryable<Post> GetByUserId(string userId);

        void Create(Post post);

        void Update(Post post);

        void OwnerDelete(string userId, int id);

        void AddComment(int postId, Comment comment);

        void DeleteComment(string userId, int id);
    }

    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public IQueryable<Post> Get(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _postRepository.Count(p => true);
            return _postRepository.Get(p => true, pageIndex, pageSize, p => p.CreateTime, false);
        }

        public IQueryable<Post> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public Post GetById(int id)
        {
            return _postRepository.Get(p => p.Id == id).Include(p => p.Creater).Include(p => p.Comments).FirstOrDefault();
        }

        public IQueryable<Post> GetByUserId(string userId)
        {
            return _postRepository.Get(p => p.CreaterId == userId).OrderByDescending(p => p.CreateTime);
        }

        public void Create(Post post)
        {
            _postRepository.Add(post);
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
            _unitOfWork.Commit();
        }

        public void OwnerDelete(string userId, int id)
        {
            var post = GetById(id);
            if (userId != post.CreaterId)
            {
                throw new Exception("Not Owner");
            }
            _postRepository.Delete(post);
            _unitOfWork.Commit();
        }


        public void AddComment(int postId, Comment comment)
        {
            var post = GetById(postId);
            post.Comments.Add(comment);
            _unitOfWork.Commit();
        }

        public void DeleteComment(string userId, int id)
        {
            var post = _postRepository.Get(p => p.Comments.Any(c => c.Id == id)).Single();
            var comment = post.Comments.Single(c => c.Id == id);
            if (post.CreaterId == userId || comment.UserId == userId)
            {
                post.Comments.Remove(comment);
                _unitOfWork.Commit();
            }
        }
    }
}