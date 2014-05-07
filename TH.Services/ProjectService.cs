using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Repositories;
using TH.Repositories.Entities;
using TH.Repositories.Infrastructure;

namespace TH.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _prejectRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProjectService(IRepository<Project> prejectRepository, IUnitOfWork unitOfWork)
        {
            _prejectRepository = prejectRepository;
            _unitOfWork = unitOfWork;
        }
    }
}
