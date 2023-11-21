using Microsoft.AspNetCore.Mvc;
using SuperLandscapes_Project.BLL.DTOs.ProjectDTO;
using SuperLandscapes_Project.SuperLandscapes_Project.BLL.Services.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/project")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        /// <summary>
        /// Information about all projects
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO also includes Paragraphs, Pictures and SVG</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProjectsAsync()
        {
            var response = await _projectService.GetAllProjectsAsync();
            return Ok(response);
        }
        /// <summary>
        /// Information about a specific project
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO also includes Paragraphs, Pictures and SVG</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectByIdAsync(Guid id)
        {
            var response = await _projectService.GetProjectByIdAsync(id);
            return Ok(response);
        }
        /// <summary>
        /// To create a project
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO also includes Paragraphs, Pictures and SVG</returns>
        [HttpPost]
        public async Task<IActionResult> CreateProjectAsync([FromBody] InsertProjectDTO insertProjectDTO)
        {
            var response = await _projectService.InsertProjectAsync(insertProjectDTO);
            return Ok(response);
        }
        /// <summary>
        /// To update already existing project
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO also includes Paragra/*phs, Pictures and SVG</returns>
       [HttpPut]
        public async Task<IActionResult> UpdateProjectAsync([FromBody] UpdateProjectDTO updateProjectDTO)
        {
            var response = await _projectService.UpdateProjectAsync(updateProjectDTO);
            return Ok(response);
        }
        /// <summary>
        /// To delete a project  by id
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO also includes Paragraphs, Pictures and SVG</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectAsync(Guid id)
        {
            var response = await _projectService.DeleteProjectByIdAsync(id);
            return Ok(response);
        }
    }
}
