
using SuperLandscapes_Project.DAL.Entities.Base;

namespace SuperLandscapes_Project.DAL.Entities
{
    public class Project : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Period { get; set; } = null!;
        public int DateYear { get; set; }
        public Guid CountryId { get; set; }
        public string RequestDescription { get; set; } = null!;
        public string RequestList { get; set; } = null!;
        public string SolutionDescription { get; set; } = null!;
        public string ResultFirstParagraph { get; set; } = null!;
        public string ResultSecondParagraph { get; set; } = null!;
        public string ResultThirdParagraph { get; set; } = null!;
    }
}
