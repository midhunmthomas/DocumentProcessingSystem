using DocumentProcessing.Data.Entities;
using DocumentProcessing.Service.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentProcessing.Service.Services
{
    public class InMemoryDocumentQueue : IDocumentQueue
    {
        private readonly ConcurrentQueue<Document> _queue = new();
        private readonly SemaphoreSlim _signal = new(0);

        public void Enqueue(Document doc)
        {
            _queue.Enqueue(doc);
            _signal.Release();
        }

        public async Task<Document> DequeueAsync(CancellationToken cancellationToken)
        {
            await _signal.WaitAsync(cancellationToken);
            _queue.TryDequeue(out var doc);
            return doc;
        }
    }

}
