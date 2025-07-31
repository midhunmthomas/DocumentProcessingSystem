using DocumentProcessing.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentProcessing.Service.Interface
{
    public interface IDocumentQueue
    {
        void Enqueue(Document document);
        Task<Document> DequeueAsync(CancellationToken cancellationToken);
    }
}
