using TekkenPortugal.WebApi.Models.Domain;

namespace TekkenPortugal.WebApi.Models.DTO
{
    public class ArticleDto
    {
        public int Id { get; set; }

        public string? Hero { get; set; }

        public string? Thumbnail { get; set; }

        public string? Title { get; set; }

        public string? Summary { get; set; }

        public string? Content { get; set; }

        public string? UrlHandle { get; set; }

        public DateTime? PublishedAt { get; set; }

        public bool IsPublished { get; set; } = false;

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public DateTime? LastUpdated { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        public ICollection<TagDto> Tags { get; set; } = new List<TagDto>();
    }
}
