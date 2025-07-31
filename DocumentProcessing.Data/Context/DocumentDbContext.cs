using Microsoft.EntityFrameworkCore;
using DocumentProcessing.Data.Entities;

namespace DocumentProcessing.Data.Context;

public class DocumentDbContext : DbContext
{
    public DbSet<Document> Documents { get; set; }

    public DocumentDbContext(DbContextOptions<DocumentDbContext> options)
        : base(options)
    {
    }
}
