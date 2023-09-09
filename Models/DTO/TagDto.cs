using TekkenPortugal.WebApi.Models.Domain;

namespace TekkenPortugal.WebApi.Models.DTO
{
    public class TagDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string UrlHandle { get; set; }
    }
}