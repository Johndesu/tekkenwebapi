﻿namespace TekkenPortugal.WebApi.Models.Domain
{
    public class Tag
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public DateTime? LastUpdated { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
