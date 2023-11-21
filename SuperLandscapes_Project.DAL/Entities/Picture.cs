
using SuperLandscapes_Project.DAL.Entities.Base;

namespace SuperLandscapes_Project.DAL.Entities
{
    public class Picture: BaseEntity
    {
        public string Url { get; set; } = null!;
        public Guid? ProjectId { get; set; }
    }
}
