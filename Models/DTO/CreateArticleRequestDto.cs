﻿namespace TekkenPortugal.WebApi.Models.DTO
{
    public class CreateArticleRequestDto
    {
        public string Hero { get; set; } = string.Empty;

        public string Thumbnail { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Summary { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime? PublishedAt { get; set; }

        public bool IsPublished { get; set; } = false;
    }
}
