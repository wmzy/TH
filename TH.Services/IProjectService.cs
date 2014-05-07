using TH.Repositories.Entities;

namespace TH.Services
{
    public interface IProjectService : IService
    {

        void Create(Project project);

        Project GetById(int id);
    }
}