

namespace SuperLandscapes_Project.DAL.Entities.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public BaseEntity()
        {
            Id= Guid.NewGuid();
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = null;
        }
    }
}
