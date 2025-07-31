using Microsoft.AspNetCore.Mvc;
using DocumentProcessing.Service;
using DocumentProcessing.Service.Interface;
using DocumentProcessing.API.ViewModel;

namespace DocumentProcessing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly IDocumentService _service;

    public DocumentsController(IDocumentService service) => _service = service;

    [HttpPost("upload")]
    public async Task<IActionResult> Upload([FromForm] IFormFileCollection files)
    {
        if (files == null || files.Count == 0)
            return BadRequest("No files uploaded");

        var result =await _service.UploadDocumentsAsync(files);

        if (result.Errors.Any())
        {
            return BadRequest(result);
        }
        return Ok("Files uploaded.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var documents = await _service.GetAllDocumentsAsync();
        return Ok(documents.Select(d => new DocumentVM
        {
            FileName = d.FileName,
            FilePath = d.FilePath,
            FileSize = d.FileSize,
            FileHash = d.FileHash,
            Metadata = d.Metadata,
            Status = d.Status.ToString()
        })
    .ToList());
    }
}
