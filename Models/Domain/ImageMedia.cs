namespace TekkenPortugal.WebApi.Models.Domain
{
    public class ImageMedia
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileExtenstion { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
