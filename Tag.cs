namespace TekkenPortugal.WebApi
{
    public class Tag
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
