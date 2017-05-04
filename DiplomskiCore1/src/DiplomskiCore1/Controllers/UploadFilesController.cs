using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Identity;
using DiplomskiCore1.Models;

namespace DiplomskiCore1.Controllers
{
    public class UploadFilesController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public UploadFilesController(
            UserManager<ApplicationUser> userManager,
            IHostingEnvironment hostingEnvironment
            )
        {
            _userManager = userManager;
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

                var userId = _userManager.GetUserId(User);
                ApplicationUser user = await _userManager.FindByIdAsync(userId);
                user.PhotoName = fileName;
                await _userManager.UpdateAsync(user);
            }
        
            return Ok(new { count = 1, file.Length, filePath });
        }
    }
}