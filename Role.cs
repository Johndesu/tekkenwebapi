namespace TekkenPortugal.WebApi
{
    public class Role
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public DateTime? LastUpdated { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
