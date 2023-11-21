using SuperLandscapes_Project.BLL.DTOs.Base;

namespace SuperLandscapes_Project.BLL.DTOs.ParagraphDTO
{
    public class UpdateParagraphDTO : UpdateBaseDTO
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Position { get; set; }
        public Guid? ProjectId { get; set; }
    }
}
