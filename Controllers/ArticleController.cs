using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using TekkenPortugal.WebApi.Data;
using TekkenPortugal.WebApi.Models.Domain;
using TekkenPortugal.WebApi.Models.DTO;
using TekkenPortugal.WebApi.Repositories.Implementation;
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

        [HttpGet]
        public async Task<IActionResult> GetAllArticles()
        {
            var articles = await articleRepository.GetAllAsync();

            var response = new List<ArticleDto>();

            foreach (var article in articles)
            {
                response.Add(new ArticleDto
                {
                    Id = article.Id,
                    Title = article.Title,
                    Thumbnail = article.Thumbnail,
                    UrlHandle = article.UrlHandle,
                    Hero = article.Hero,
                    Summary = article.Summary,
                    Content = article.Content,
                    PublishedAt = article.PublishedAt,
                    IsPublished = article.IsPublished,
                    LastUpdated = article.LastUpdated,
                    IsDeleted = article.IsDeleted
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetArticleById(int id)
        {
            var existingArticle = await articleRepository.GetById(id);

            

            if (existingArticle != null)
            {
                var response = new ArticleDto
                {
                    Id = existingArticle.Id,
                    Title = existingArticle.Title,
                    Thumbnail = existingArticle.Thumbnail,
                    UrlHandle = existingArticle.UrlHandle,
                    Hero = existingArticle.Hero,
                    Summary = existingArticle.Summary,
                    Content = existingArticle.Content,
                    PublishedAt = existingArticle.PublishedAt,
                    IsPublished = existingArticle.IsPublished,
                    LastUpdated = existingArticle.LastUpdated,
                    IsDeleted = existingArticle.IsDeleted
                };
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }


        //Create the Article Action
        [HttpPost]
        public async Task<IActionResult> CreateArticle(CreateArticleRequestDto request)
        {
            // Map DTO to Domain Model
            var article = new Article
            {
                Id = request.Id,
                Hero = request.Hero,
                Thumbnail = request.Thumbnail,
                Title = request.Title,
                UrlHandle = request.UrlHandle,
                Summary = request.Summary,
                Content = request.Content,
                PublishedAt = request.PublishedAt,
                IsPublished = request.IsPublished,
                IsDeleted = request.IsDeleted,

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


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateArticle(int id, UpdateArticleRequestDto request)
        {
            // Convert DTO to Domain Model
            var article = new Article
            {
                Id = id,
                Hero = request.Hero,
                Thumbnail = request.Thumbnail,
                Title = request.Title,
                UrlHandle = request.UrlHandle,
                Summary = request.Summary,
                Content = request.Content,
                PublishedAt = request.PublishedAt,
                IsPublished = request.IsPublished,
                IsDeleted = request.IsDeleted,
            };

            article = await articleRepository.UpdateAsync(article);

            if (article == null)
            {
                return NotFound();
            }

            var response = new ArticleDto
            {
                Id = article.Id,
                Title = article.Title
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var article = await articleRepository.DeleteAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            //Convert Domain Model to Dto
            var resposne = new ArticleDto
            {
                Id = article.Id,
                Title = article.Title
            };

            return Ok(resposne);
        }

    }
}
