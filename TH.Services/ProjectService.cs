using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Model;
using TH.Repositories;
using TH.Repositories.Infrastructure;
using TH.Repositories.Repository;

namespace TH.Services
{
    public interface IProjectService : IService
    {

        void Create(Project project);

        Project GetById(int id);

        void OwnerDelete(string p, int id);

        void Update(Project project);

        IQueryable<Project> Get();
    }
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProjectService(IProjectRepository prejectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = prejectRepository;
            _unitOfWork = unitOfWork;
        }

        public void Create(Project project)
        {
            _projectRepository.Add(project);
            _unitOfWork.Commit();
        }

        public Project GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void OwnerDelete(string p, int id)
        {
            throw new NotImplementedException();
        }


        public void Update(Project project)
        {
            throw new NotImplementedException();
        }


        public IQueryable<Project> Get()
        {
            throw new NotImplementedException();
        }
    }
}
