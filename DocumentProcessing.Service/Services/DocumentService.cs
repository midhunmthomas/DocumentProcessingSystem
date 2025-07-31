using System.Security.Cryptography;
using System.Text;
using DocumentProcessing.Data.Entities;
using DocumentProcessing.Data.Interface;
using DocumentProcessing.Service.Interface;
using Microsoft.AspNetCore.Http;

namespace DocumentProcessing.Service.Services;

public class DocumentService : IDocumentService
{
    private readonly IDocumentRepository _repository;
    private readonly IDocumentQueue _queue;

    public DocumentService(IDocumentRepository repository, IDocumentQueue queue)
    {
        _repository = repository;
        _queue = queue;
    }

    public async Task<UploadResult> UploadDocumentsAsync(IFormFileCollection files)
    {

        var result = new UploadResult();

        foreach (var file in files)
        {
            if (!file.FileName.EndsWith(".pdf"))
            {
                result.Errors.Add($"{file.FileName} is not a PDF file.");
                continue;
            }
                
            if (file.Length > 10 * 1024 * 1024)
            {
                result.Errors.Add($"{file.FileName} exceeds the 10MB size limit.");
                continue;
            }

            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var hash = ComputeHash(ms.ToArray());

            if (await _repository.GetByHashAsync(hash) != null)
            {
                result.Errors.Add($"{file.FileName} is a duplicate and was skipped.");
                continue;
            }
                

            var filePath = Path.Combine("Uploads", Guid.NewGuid() + ".pdf");
       

            var doc = new Document
            {
                FileName = file.FileName,
                FilePath = filePath,
                FileSize = file.Length,
                FileHash = hash,
                Metadata = "{}",
                Status = DocumentStatus.Uploaded
            };

            await _repository.AddAsync(doc);
            await _repository.SaveChangesAsync();

            _queue.Enqueue(doc);
            result.UploadedFiles.Add(file.FileName);
        }
        return result;
    }

    public async Task<List<Document>> GetAllDocumentsAsync()
    {
       var docs = await _repository.GetAllAsync();
       
        return docs;
    }
        

    private string ComputeHash(byte[] content)
    {
        using var sha = SHA256.Create();
        return Convert.ToBase64String(sha.ComputeHash(content));
    }

    
}
