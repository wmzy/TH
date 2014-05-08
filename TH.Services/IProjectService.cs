using TH.Model;

namespace TH.Services
{
    public interface IProjectService : IService
    {

        void Create(Project project);

        Project GetById(int id);

        void OwnerDelete(string p, int id);

        void Update(Project project);
    }
}