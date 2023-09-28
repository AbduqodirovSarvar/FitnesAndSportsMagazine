using Fitnes.Application.UseCases.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fitnes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpGet]
        [Route("{FileName}")]
        public IActionResult Get([FromRoute] string FileName)
        {
            try
            {
                var contentType = "image/png";
                string folderPath = Directory.GetCurrentDirectory();
                string filePath = Path.Combine(folderPath, "..", "Fitnes.Application", "Files", "Images", FileName);
                string fullPath = Path.GetFullPath(filePath);
                contentType = "image/" + FileName.Split('.').Last().ToString();

                return PhysicalFile(fullPath, contentType);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("All")]
        public IActionResult GetAllFile()
        {
            try
            {
                string folderPath = Directory.GetCurrentDirectory();
                string fullPath = Path.GetFullPath(Path.Combine(folderPath, "..", "Fitnes.Application", "Files", "Images"));

                var files = Directory.GetFiles(fullPath).Select(x => Path.GetFileName(x)).ToList();

                return Ok(files);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
