namespace DigiLean.Api.Model.V1.Attachments
{
    public class Attachment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string FileName { get; set; } = string.Empty;

        public string? FileExtension { get; set; }
        public long FileSizeInKb { get; set; }
        public string? Url { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedByUserId { get; set; }
        public string? CreatedByUser { get; set; } = string.Empty;
        public string? ContentType { get; set; }

    }
}
