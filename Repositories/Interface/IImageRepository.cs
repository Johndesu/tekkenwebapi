using TekkenPortugal.WebApi.Models.Domain;

namespace TekkenPortugal.WebApi.Repositories.Interface
{
    public interface IImageRepository
    {
        Task<ImageMedia> Upload(IFormFile file, ImageMedia articleImage);

        Task<IEnumerable<ImageMedia>> GetImages();

        Task<ImageMedia> DeleteAsync(int id);
    }
}
