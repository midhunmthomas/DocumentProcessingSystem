using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentProcessing.Service.Services
{
    public class UploadResult
    {
        public List<string> UploadedFiles { get; set; } = new();
        public List<string> Errors { get; set; } = new();
    }
}
