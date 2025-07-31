using DocumentProcessing.Data.Entities;

namespace DocumentProcessing.API.ViewModel
{
    public class DocumentVM
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public string FileHash { get; set; }
        public string Metadata { get; set; }
        public string Status { get; set; }
        public string UploadedAt { get; set; }
    }
}
