
namespace SuperLandscapes_Project.BLL.DTOs.PictureDTO
{
    public class InsertPictureDTO
    {
        public string Url { get; set; } = null!;
        public int Position { get; set; }
        public Guid? ProjectId { get; set; }
    }
}
