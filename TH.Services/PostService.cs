using System;
using System.Collections.Generic;
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

        void OwnerDelete(string ownerId, int id);
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
            throw new NotImplementedException();
        }

        public IQueryable<Post> GetByLocation(string location, int pageIndex, int pageSize, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public Post GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Post> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void Create(Post post)
        {
            throw new NotImplementedException();
        }

        public void Update(Post post)
        {
            throw new NotImplementedException();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            throw new NotImplementedException();
        }
    }
}