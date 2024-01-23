using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpGet("download/{fileName}")]
        public IActionResult DownloadImage(string fileName)
        {
            var filePath = Path.Combine("Uploads/", fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found");
            }

            var fileStream = System.IO.File.OpenRead(filePath);
            var contentType = "application/octet-stream";
            return File(fileStream, contentType, fileName);
        }
    }
}
