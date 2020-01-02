using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace evaporate.Controllers
{
    [ApiController]
    [Route("File")]
    public class FileController : ControllerBase
    {
        ILogger<FileController> _logger;
        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload()
        {
            var files = Request.Form.Files;
            if (files == null || !files.Any())
                return NoContent();
            foreach(var file in files)
            {
                await CopyFileAsync(file);
            }

            return Ok();
        }

        public async Task CopyFileAsync(IFormFile file)
        {
            var path = System.IO.Path.Combine(contentPath, file.FileName);
            var stream = System.IO.File.OpenWrite(path);
            await file.CopyToAsync(stream);
        }


        static string contentPath = System.IO.Path.Combine(Program.ContentRoot(), "Contents");
        static FileController()
        {
            if (!System.IO.Directory.Exists(contentPath))
                System.IO.Directory.CreateDirectory(contentPath);
        }
    }
}
