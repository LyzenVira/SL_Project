using SuperLandscapes_Project.BLL.DTOs.Base;

namespace SuperLandscapes_Project.BLL.DTOs.PictureDTO
{
    public class UpdatePictureDTO : UpdateBaseDTO
    {
        public string Url { get; set; } = null!;
        public int Position { get; set; }
        public Guid? ProjectId { get; set; }
    }
}
