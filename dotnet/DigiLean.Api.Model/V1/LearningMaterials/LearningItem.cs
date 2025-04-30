namespace DigiLean.Api.Model.V1.LearningMaterials
{
    public class LearningChapter
    {
        public string? Title { get; set; }
        public int SortOrder { get; set; }
        public List<LearningPage> Pages { get; set; } = new List<LearningPage>();
    }

    public class LearningPage
    {
        public string? Title { get; set; }
        public int SortOrder { get; set; }
        public List<LearningItemSection> Sections { get; set; } = new List<LearningItemSection>();
    }

}
