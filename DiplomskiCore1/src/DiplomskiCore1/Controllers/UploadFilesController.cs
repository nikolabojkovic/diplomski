using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Net.Http.Headers;

namespace DiplomskiCore1.Controllers
{
    public class UploadFilesController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public UploadFilesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage()
        {
            var file = HttpContext.Request.Form.Files.FirstOrDefault();
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse
                    (file.ContentDisposition).FileName.Trim('"');
                
               // file.SaveAs(Path.Combine(uploads, fileName));

                using (var stream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return Ok(new { count = 1, file.Length, filePath });
        }
    }
}