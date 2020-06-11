using System;
using System.IO;
using System.IO.Compression;
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
        public IActionResult Upload()
        {
            try
            {
                var files = Request.Form.Files;
                if (files == null || !files.Any())
                    return NoContent();

                if (files.Count() > 1)
                    return BadRequest("Cannot accept more than one file");

                var file = files.FirstOrDefault();

                if (file == null)
                    return BadRequest("Invalid file");

                if (System.IO.Path.GetExtension(file.FileName) != ".zip")
                    return BadRequest("Only zip files are accepted");

                return Content(CopyFile(file));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        public string CopyFile(IFormFile file)
        {
            var path = Path.Combine(contentPath, file.FileName);
            using (var stream = System.IO.File.OpenWrite(path))
            {
                file.CopyTo(stream);
            }
            return Unzip(path);
        }

        private string Unzip(string zipFile)
        {
            var uuid = Guid.NewGuid();
            var destDir = Path.Combine(contentPath, uuid.ToString());
            if (!Directory.Exists(destDir))
                Directory.CreateDirectory(destDir);

            ZipFile.ExtractToDirectory(zipFile, destDir);
            return destDir;
        }

        static readonly string
            contentPath = Path.Combine(Program.ContentRoot(), "Contents");
        static FileController()
        {
            if (!Directory.Exists(contentPath))
                Directory.CreateDirectory(contentPath);
        }
    }
}
