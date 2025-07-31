using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentProcessing.Data.Entities
{
    public class Document
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public string FileHash { get; set; }
        public string Metadata { get; set; }
        public DocumentStatus Status { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}
