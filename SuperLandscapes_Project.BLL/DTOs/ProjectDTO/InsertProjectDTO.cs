using SuperLandscapes_Project.BLL.DTOs.CountryDTO;
using SuperLandscapes_Project.BLL.DTOs.ParagraphDTO;
using SuperLandscapes_Project.BLL.DTOs.PictureDTO;
using SuperLandscapes_Project.BLL.DTOs.TechnologyDTO;

namespace SuperLandscapes_Project.BLL.DTOs.ProjectDTO
{
    public class InsertProjectDTO
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Period { get; set; } = null!;
        public int DateYear { get; set; }
        public string RequestDescription { get; set; } = null!;
        public string RequestList { get; set; } = null!;
        public string SolutionDescription { get; set; } = null!;
        public string ResultFirstParagraph { get; set; } = null!;
        public string ResultSecondParagraph { get; set; } = null!;
        public string ResultThirdParagraph { get; set; } = null!;
        public List<InsertPictureDTO> Pictures { get; set; } = null!;
        public List<InsertParagraphDTO> Paragraphs { get; set; } = null!;
        public List<InsertTechnologyDTO> Technologies { get; set; } = null!;
        public InsertCountryDTO Country { get; set; } = null!;
    }
}
