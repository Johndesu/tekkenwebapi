using Microsoft.EntityFrameworkCore;
using TekkenPortugal.WebApi.Data;
using TekkenPortugal.WebApi.Models.Domain;
using TekkenPortugal.WebApi.Repositories.Interface;

namespace TekkenPortugal.WebApi.Repositories.Implementation
{
    public class ImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly DataContext _context;

        public ImageRepository(
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            DataContext dbContext
        )
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            _context = dbContext;
        }

        public async Task<IEnumerable<ImageMedia>> GetImages()
        {
            return await _context.ImagesMedia.ToListAsync();
        }

        public async Task<ImageMedia> Upload(IFormFile file, ImageMedia articleImage)
        {
            // 1- Upload the Image to API/Images
            var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{articleImage.FileName}{articleImage.FileExtenstion}");

            using var stream = new FileStream(localPath, FileMode.Create);
            await file.CopyToAsync(stream);

            // 2- Update the database
            var httpRequest = httpContextAccessor.HttpContext.Request;
            var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/{articleImage.FileName}{articleImage.FileExtenstion}";

            articleImage.Url = urlPath;

            await _context.ImagesMedia.AddAsync(articleImage);
            await _context.SaveChangesAsync();

            return articleImage;

        }

        public async Task<ImageMedia> DeleteAsync(int id)
        {
            var existingImage = await _context.ImagesMedia.FirstOrDefaultAsync(x => x.Id == id);

            if (existingImage != null)
            {
                //Delete image from folder
                var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{existingImage.FileName}{existingImage.FileExtenstion}");
                if (File.Exists(localPath))
                {
                    File.Delete(localPath);
                }

                //Delete from DB
                _context.ImagesMedia.Remove(existingImage);
                await _context.SaveChangesAsync();

                return existingImage;

            }

            return null;
        }
    }
}
