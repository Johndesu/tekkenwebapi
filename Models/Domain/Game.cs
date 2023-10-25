namespace TekkenPortugal.WebApi.Models.Domain
{
    public class Game
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public string StartggId { get; set; } = string.Empty;

        public string ChallongeId { get; set; } = string.Empty;

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public DateTime? LastUpdated { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
