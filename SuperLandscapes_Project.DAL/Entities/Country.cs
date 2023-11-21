using SuperLandscapes_Project.DAL.Entities.Base;

namespace SuperLandscapes_Project.DAL.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
    }
}
