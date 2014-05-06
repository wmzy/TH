using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Repositories;
using TH.Repositories.Entities;

namespace TH.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _prejectRepository;
        public ProjectService(IRepository<Project> prejectRepository)
        {
            _prejectRepository = prejectRepository;
        }
    }
}
