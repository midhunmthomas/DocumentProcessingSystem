using DocumentProcessing.Data.Context;
using DocumentProcessing.Data.Interface;
using DocumentProcessing.Data.Repository;
using DocumentProcessing.Service.Interface;
using DocumentProcessing.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Use SQL Server (adjust connection string as needed)
builder.Services.AddDbContext<DocumentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddSingleton<IDocumentQueue, InMemoryDocumentQueue>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddHostedService<DocumentBackgroundService>();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
