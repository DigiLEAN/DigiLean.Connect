namespace DigiLean.Api.Model.V1.LearningMaterials
{
    public class LearningBase
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Language { get; set; }
        public DateTime LastModified { get; set; }
    }

    public class LearningInfo : LearningBase
    {
        public int Id { get; set; }
    }

    public class LearningMaterial : LearningInfo
    {
        public string? ImageId { get; set; }
        public string? ImageUrl { get; set; }
        public List<LearningChapter> Chapters { get; set; } = new List<LearningChapter>();
    }
}
