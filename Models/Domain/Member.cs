namespace TekkenPortugal.WebApi.Models.Domain
{
    public class Member
    {
        public int Id { get; set; }

        public string Nickname { get; set; } = string.Empty;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? SocialMedia { get; set; }

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public DateTime? LastUpdated { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
