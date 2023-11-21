using SuperLandscapes_Project.DAL.Entities.Base;

namespace SuperLandscapes_Project.DAL.Entities
{
    public class ProjectTechnology
    {
        public Guid TechnologyId { get; set; }
        public Guid ProjectId { get; set; }
    }
}
