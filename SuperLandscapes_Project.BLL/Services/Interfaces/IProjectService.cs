

using SuperLandscapes_Project.BLL.DTOs.ProjectDTO;

namespace SuperLandscapes_Project.SuperLandscapes_Project.BLL.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<GetProjectDTO>> GetAllProjectsAsync();
        Task<GetProjectDTO> GetProjectByIdAsync(Guid id);
        Task<GetProjectDTO> InsertProjectAsync(InsertProjectDTO projectDTO);
        Task<GetProjectDTO> UpdateProjectAsync(UpdateProjectDTO updateProjectDTO);
        Task<string> DeleteProjectByIdAsync(Guid id);
    }
}
