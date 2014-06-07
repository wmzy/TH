using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TH.Model;
using TH.Repositories;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface IProjectService : IService
    {
        IQueryable<Project> Get(int pageIndex, int pageSize, out int recordCount);
        IQueryable<Project> Get();

        Project GetById(int id);
        IQueryable<Project> GetByUserId(string userId);

        void Create(Project project);

        void Update(Project project);

        void OwnerDelete(string ownerId, int id);
    }
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public Project GetById(int id)
        {
            return _projectRepository.Get(m => m.Id == id).FirstOrDefault();
        }
        public IQueryable<Project> Get(int pageIndex, int pageSize, out int recordCount)
        {
            recordCount = _projectRepository.Count(m => true);
            return _projectRepository.Get(m => true, pageIndex, pageSize, m => m.CreateDate);
        }
        public IQueryable<Project> Get()
        {
            return _projectRepository.Get().OrderByDescending(j => j.CreateDate);
        }

        public IQueryable<Project> GetByUserId(string userId)
        {
            return _projectRepository.Get(j => j.Publisher.Id == userId);
        }

        public void Create(Project project)
        {
            _projectRepository.Add(project);
            _unitOfWork.Commit();
        }


        public void Update(Project project)
        {
            _projectRepository.Update(project);
            _unitOfWork.Commit();
        }

        public void OwnerDelete(string ownerId, int id)
        {
            var project = GetById(id);

            if (project != null && project.PublisherId == ownerId)
            {
                _projectRepository.Delete(project);
                _unitOfWork.Commit();
            }
        }
    }
}
