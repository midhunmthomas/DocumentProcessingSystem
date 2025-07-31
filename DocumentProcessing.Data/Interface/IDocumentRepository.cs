using DocumentProcessing.Data.Entities;

namespace DocumentProcessing.Data.Interface;

public interface IDocumentRepository
{
    Task AddAsync(Document document);
    Task<Document> GetByHashAsync(string hash);
    Task<List<Document>> GetAllAsync();
    Task SaveChangesAsync();
}
