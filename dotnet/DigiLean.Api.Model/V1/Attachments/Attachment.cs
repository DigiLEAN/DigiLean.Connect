using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DigiLean.Api.Model.V1.Attachments
{
    public class Attachment
    {
        public string Id { get; set; } // GUID
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public long FileSizeInKb { get; set; }
        public string Url { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public string CreatedByUser { get; set; } = string.Empty;
        public string ContentType { get; set; }

    }
}
