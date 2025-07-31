using Microsoft.EntityFrameworkCore;
using DocumentProcessing.Data.Entities;
using DocumentProcessing.Data.Interface;
using DocumentProcessing.Data.Context;

namespace DocumentProcessing.Data.Repository;

public class DocumentRepository : IDocumentRepository
{
    private readonly DocumentDbContext _context;

    public DocumentRepository(DocumentDbContext context) => _context = context;

    public async Task AddAsync(Document document) => await _context.Documents.AddAsync(document);

    public async Task<Document> GetByHashAsync(string hash) =>
        await _context.Documents.FirstOrDefaultAsync(d => d.FileHash == hash);

    public async Task<List<Document>> GetAllAsync() =>
        await _context.Documents.ToListAsync();

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}
