using TekkenPortugal.WebApi.Models.Domain;

namespace TekkenPortugal.WebApi.Models.DTO
{
    public class ArticleDto
    {
        public int Id { get; set; }

        public string Hero { get; set; } = string.Empty;

        public string Thumbnail { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Summary { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string UrlHandle { get; set; } = string.Empty;

        public DateTime? PublishedAt { get; set; }

        public bool IsPublished { get; set; } = false;

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public DateTime? LastUpdated { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<Category> Categories { get; set; } = new List<Category>();

        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
