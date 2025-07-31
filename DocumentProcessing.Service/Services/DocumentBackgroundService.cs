using DocumentProcessing.Data.Entities;
using DocumentProcessing.Data.Interface;
using DocumentProcessing.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DocumentProcessing.Service.Services
{
    public class DocumentBackgroundService : BackgroundService
    {
        private readonly IDocumentQueue _queue;
        private readonly IServiceScopeFactory _scopeFactory;

        public DocumentBackgroundService(IDocumentQueue queue, IServiceScopeFactory scopeFactory)
        {
            _queue = queue;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var doc = await _queue.DequeueAsync(stoppingToken);

                using (var scope = _scopeFactory.CreateScope())
                {
                    var repository = scope.ServiceProvider.GetRequiredService<IDocumentRepository>();

                    doc.Status = DocumentStatus.Processing;
                    await repository.SaveChangesAsync();

                    await Task.Delay(2000); 

                    doc.Metadata = $"Dummy metadata: WordCount={new Random().Next(100, 1000)}";
                    doc.Status = DocumentStatus.Completed;

                    await repository.SaveChangesAsync();
                }
            }
        }
    }
}
