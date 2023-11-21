namespace SuperLandscapes_Project.BLL.DTOs.ParagraphDTO
{
    public class InsertParagraphDTO
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Position { get; set; }
        public Guid? ProjectId { get; set; }
    }
}
