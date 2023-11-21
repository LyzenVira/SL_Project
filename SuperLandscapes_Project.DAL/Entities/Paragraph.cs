
using SuperLandscapes_Project.DAL.Entities.Base;

namespace SuperLandscapes_Project.DAL.Entities
{
    public class Paragraph : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid? ProjectId { get; set; }
    }
}
