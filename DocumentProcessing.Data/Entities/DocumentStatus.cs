using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentProcessing.Data.Entities
{
    public enum DocumentStatus
    {
        Uploaded,
        Processing,
        Completed,
        Duplicate
    }
}
