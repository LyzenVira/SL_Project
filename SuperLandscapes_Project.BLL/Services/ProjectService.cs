using AutoMapper;
using SuperLandscapes_Project.BLL.DTOs.CountryDTO;
using SuperLandscapes_Project.BLL.DTOs.ProjectDTO;
using SuperLandscapes_Project.BLL.DTOs.TechnologyDTO;
using SuperLandscapes_Project.DAL.Entities;
using SuperLandscapes_Project.DAL.UnitOfWork.Interface;
using SuperLandscapes_Project.SuperLandscapes_Project.BLL.Services.Interfaces;

namespace SuperLandscapes_Project.SuperLandscapes_Project.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public ProjectService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> DeleteProjectByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.ProjectRepository.GetByIdAsync(id) ?? throw new Exception("Not found exception");
            await _unitOfWork.ProjectRepository.DeleteAsync(id);
            _unitOfWork.Save();

            return "Successful delete!";
        }
        public async Task<GetProjectDTO> GetProjectByIdAsync(Guid id)
        {
            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(id);

            var technologies = _unitOfWork.ProjectTechnologyRepository.GetTechnologiesByProjectId(project.Id);
            if (technologies == null) 
            { 
                throw new Exception("Not found Technologies!"); 
            }
            var projectDto = _mapper.Map<GetProjectDTO>(project);
            projectDto.Technologies = _mapper.Map<IEnumerable<DAL.Entities.Technology>, List<GetTechnologyDTO>>(technologies);

            return projectDto;
        }

        public async Task<IEnumerable<GetProjectDTO>> GetAllProjectsAsync()
        {
            var projects = await _unitOfWork.ProjectRepository.GetAllAsync();
            var projectsDTO = _mapper.Map<IEnumerable<GetProjectDTO>>(projects);

            foreach (var projectDto in projectsDTO)
            {
                var technologies =  _unitOfWork.ProjectTechnologyRepository.GetTechnologiesByProjectId(projectDto.Id);
                if (technologies == null || technologies.Count() == 0) 
                { 
                    throw new Exception("Not found Technologies!"); 
                }
                projectDto.Technologies = _mapper.Map<IEnumerable<DAL.Entities.Technology>, List<GetTechnologyDTO>>(technologies);

            }

            return projectsDTO;
        }


        public async Task<GetProjectDTO> UpdateProjectAsync(UpdateProjectDTO updateProjectDTO)
        {
            var project = _mapper.Map<UpdateProjectDTO, Project>(updateProjectDTO);
            var country = await _unitOfWork.CountryRepository.GetByIdAsync(project.CountryId);

            if (country is null)
            {
                updateProjectDTO.Country.Id = Guid.NewGuid();
                country = await _unitOfWork.CountryRepository.CreateAsync(_mapper.Map<Country>(updateProjectDTO.Country));
            }
            project.CountryId = country.Id;

            foreach (var paragraph in updateProjectDTO.Paragraphs)
            {
                paragraph.ProjectId = project.Id;
                await _unitOfWork.ParagraphRepository.UpdateAsync(_mapper.Map<Paragraph>(paragraph));
            }

            foreach (var picture in updateProjectDTO.Pictures)
            {
                picture.ProjectId = project.Id;
                await _unitOfWork.PictureRepository.UpdateAsync(_mapper.Map<Picture>(picture));
            }

            var technologies = _unitOfWork.ProjectTechnologyRepository.GetTechnologiesByProjectId(project.Id);
            var findtechnology = await _unitOfWork.TechnologyRepository.GetAllAsync();

            foreach (var technologyDTO in _mapper.ProjectTo<DAL.Entities.Technology>(updateProjectDTO.Technologies.AsQueryable()))
            {
                var existingTechnology = technologies.FirstOrDefault(t => t.Name == technologyDTO.Name);
                var existinOfAllTechnology = findtechnology.FirstOrDefault(t => t.Name == technologyDTO.Name);
                if (existinOfAllTechnology is null)
                {
                    var tech = await _unitOfWork.TechnologyRepository.CreateAsync(technologyDTO);
                    _unitOfWork.ProjectTechnologyRepository.AddProjectTechnology(project, tech);
                }
                else if (existingTechnology is null)
                {
                    technologyDTO.Id = existinOfAllTechnology.Id;
                    _unitOfWork.ProjectTechnologyRepository.AddProjectTechnology(project, technologyDTO);
                }
                else
                {
                    technologyDTO.Id = existingTechnology.Id;
                    await _unitOfWork.TechnologyRepository.UpdateAsync(technologyDTO);
                }

            }
            foreach (var technology in technologies)
            {
                if (!updateProjectDTO.Technologies.Any(t => t.Id == technology.Id))
                {
                 _unitOfWork.ProjectTechnologyRepository.DeleteProjectTechnology(project.Id, technology.Id);
                }
            }
            var projectORBlogTechnologies = _unitOfWork.ProjectTechnologyRepository.GetProjectTechnologiesByProjectId(project.Id);
            var response = await _unitOfWork.ProjectRepository.UpdateAsync(project);
            
            _unitOfWork.Save();

            return _mapper.Map<GetProjectDTO>(response);
        }
        public async Task<GetProjectDTO> InsertProjectAsync(InsertProjectDTO projectDTO)
        {
            var project = _mapper.Map<InsertProjectDTO, Project>(projectDTO);

            var countries = await _unitOfWork.CountryRepository.GetAllAsync();
            var country = countries.FirstOrDefault(x => x.Code == projectDTO.Country.Code);

            if (country is null)
            {
                country = await _unitOfWork.CountryRepository.CreateAsync(_mapper.Map<InsertCountryDTO, Country>(projectDTO.Country));
            }
            project.CountryId = country.Id;


            foreach (var paragraph in projectDTO.Paragraphs)
            {
                paragraph.ProjectId = project.Id;
                await _unitOfWork.ParagraphRepository.CreateAsync(_mapper.Map<Paragraph>(paragraph));
            }

            foreach (var picture in projectDTO.Pictures)
            {
                picture.ProjectId = project.Id;
                await _unitOfWork.PictureRepository.CreateAsync(_mapper.Map<Picture>(picture));
            }

            var technologies = await _unitOfWork.TechnologyRepository.GetAllAsync();

            foreach (var technologyDTO in _mapper.ProjectTo<DAL.Entities.Technology>(projectDTO.Technologies.AsQueryable()))
            {
                var technology = technologies.FirstOrDefault(x => x.Name == technologyDTO.Name);

                if (technology is null)
                {
                    technology = await _unitOfWork.TechnologyRepository.CreateAsync(technologyDTO);
                }
              _unitOfWork.ProjectTechnologyRepository.AddProjectTechnology(project, technology);
            }


            var response = await _unitOfWork.ProjectRepository.CreateAsync(project);
             _unitOfWork.Save();

            return _mapper.Map<GetProjectDTO>(response);
        }
    }
}
