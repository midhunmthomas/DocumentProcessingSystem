using Microsoft.AspNetCore.Http;
using DocumentProcessing.Data.Entities;
using DocumentProcessing.Service.Services;

namespace DocumentProcessing.Service.Interface
{
    public interface IDocumentService
    {
         Task<UploadResult> UploadDocumentsAsync(IFormFileCollection files);

         Task<List<Document>> GetAllDocumentsAsync();
    }
}
