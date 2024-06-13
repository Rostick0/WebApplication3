using ImageMagick;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using WebApplication3.Data;
using WebApplication3.Utils;


namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController(ApiContext context) : ControllerBase
    {
        private readonly ApiContext context = context;
        private readonly string pathStorageImage = Path.Combine("Resources", "Upload", "Images");

        [HttpPost]
        public async Task<ActionResult<string>> Create(IFormFile file)
        {
            DateTime now = DateTime.Now;

            string folderDate = Path.Combine(now.Year.ToString(), now.Month.ToString(), now.Day.ToString());
            string folderName = Path.Combine(this.pathStorageImage, folderDate);
            string fileName = new Random().Next(1000, 9999).ToString() + now.Ticks.ToString() + Path.GetExtension(file.FileName).ToLower();
            string filePath = Path.Combine(folderName, fileName);
            string filePathWithDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);

            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), folderName)))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), folderName));
            }

            using (var fileStream = new FileStream(filePathWithDirectory, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            ImageOptimizer optimizer = new();
            optimizer.Compress(filePathWithDirectory);

            return filePathWithDirectory;
        }

        [HttpGet("{year}/{month}/{day}/{fileName}")]
        public ActionResult Get(string year, string month, string day, string fileName, int? w, int? h)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), this.pathStorageImage, year, month, day, fileName);
            try
            {
                using (var image = Image.FromFile(filePath))
                {
                    using (Bitmap resizedImage = new(image, new Size(w ?? image.Width, h ?? image.Height)))
                    {
                        using (MemoryStream ms = new())
                        {
                            resizedImage.Save(ms, ImageHelper.getImageFormat(filePath));

                            return new FileContentResult(ms.ToArray(), MimeKit.MimeTypes.GetMimeType(fileName));
                        }
                    }
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
