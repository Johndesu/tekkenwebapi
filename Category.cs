namespace TekkenPortugal.WebApi
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
