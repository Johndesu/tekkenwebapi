using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TekkenPortugal.WebApi.Models.Domain;
using TekkenPortugal.WebApi.Models.DTO;
using TekkenPortugal.WebApi.Repositories.Interface;

namespace TekkenPortugal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(
            IImageRepository imageRepository
        )
        {
            this.imageRepository = imageRepository;
        }

        // GET : {apibaseurl}/api/images
        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            // call image repository to get all images
            var images = await imageRepository.GetImages();

            // Convert Domain model to dto
            var response = new List<ArticleImageDto>();
            foreach (var image in images)
            {
                response.Add(new ArticleImageDto
                {
                    Id = image.Id,
                    Title = image.Title,
                    DateCreated = image.DateCreated,
                    FileExtenstion = image.FileExtenstion,
                    FileName = image.FileName,
                    Url = image.Url
                });
            }

            return Ok(response);
        }



        // POST: {apibaseurl}/api/images
        [HttpPost]
        public async Task<IActionResult> UploadImage(
            [FromForm] IFormFile file,
            [FromForm] string fileName,
            [FromForm] string title
            )
        {
            ValidateFileUpload(file);

            if(ModelState.IsValid)
            {
                // File upload
                var articleImage = new ImageMedia
                {
                    FileExtenstion = Path.GetExtension(file.FileName).ToLower(),
                    FileName = fileName,
                    Title = title,
                    DateCreated = DateTime.Now
                };

                articleImage = await imageRepository.Upload(file, articleImage);

                //Convert Domain Model to DTO
                var response = new ArticleImageDto
                {
                    Id = articleImage.Id,
                    Title = articleImage.Title,
                    DateCreated = articleImage.DateCreated,
                    FileExtenstion = articleImage.FileExtenstion,
                    FileName = articleImage.FileName,
                    Url = articleImage.Url
                };

                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        //DELETE: {apibaseurl}/api/images
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var articleImage = await imageRepository.DeleteAsync(id);

                if(articleImage == null)
                {
                    return NotFound();
                }

                //Convert Domain Model to Dto
                var response = new ArticleImageDto
                {
                    Id = articleImage.Id,
                    Title = articleImage.Title,
                    DateCreated = DateTime.Now
                };

                return Ok(response);
        }

        private void ValidateFileUpload(IFormFile file)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                ModelState.AddModelError("file", "Unsupported File Format");
            }

            if (file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size cannot be more than 10MB");
            }
        }

    }
}
