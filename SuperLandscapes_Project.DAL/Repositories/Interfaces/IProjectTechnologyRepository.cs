
using SuperLandscapes_Project.DAL.Entities;

namespace SuperLandscapes_Project.DAL.Repositories.Interfaces
{
    public interface IProjectTechnologyRepository
    {
        void AddProjectTechnology(Project project, Technology technology);
        void DeleteProjectTechnology(Guid projectId, Guid technologyId);
        IEnumerable<ProjectTechnology> GetProjectTechnologiesByProjectId(Guid projectId);
        IEnumerable<ProjectTechnology> GetAllProjectTechnologies();
        IEnumerable<Technology> GetTechnologiesByProjectId(Guid projectId);
    }
}
