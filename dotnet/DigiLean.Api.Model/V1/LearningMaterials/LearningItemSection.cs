namespace DigiLean.Api.Model.V1.LearningMaterials
{
    public class LearningItemSection
    {
        public string? SectionType { get; set; }
        public string? Title { get; set; }
        public int SortOrder { get; set; }
        public string? Url { get; set; }
        public string? Content { get; set; }
        public string? FileId { get; set; }
        public LearningFile? File { get; set; }
    }
}
