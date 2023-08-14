using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TekkenPortugal.WebApi.Data;
using TekkenPortugal.WebApi.Models.Domain;
using TekkenPortugal.WebApi.Models.DTO;
using TekkenPortugal.WebApi.Repositories.Interface;

namespace TekkenPortugal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        public readonly IArticleRepository articleRepository;

        public ArticleController(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        //Create the Article Action
        [HttpPost]
        public async Task<IActionResult> CreateArticle(CreateArticleRequestDto request)
        {
            // Map DTO to Domain Model
            var article = new Article
            {
                Hero = request.Hero,
                Thumbnail = request.Thumbnail,
                Title = request.Title,
                Summary = request.Summary,
                Content = request.Content,
                PublishedAt = request.PublishedAt,
                IsPublished = request.IsPublished

            };

            await articleRepository.CreateAsync(article);

           

            // Dpomain model to DTO

            var response = new ArticleDto
            {
                Id = article.Id,
                Title = article.Title

            };

            return Ok(response);

        }

    }
}
