using Microsoft.AspNetCore.Mvc;
using TekkenPortugal.WebApi.Data;
using TekkenPortugal.WebApi.Models.Domain;
using TekkenPortugal.WebApi.Models.DTO;
using TekkenPortugal.WebApi.Repositories.Interface;

namespace TekkenPortugal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await categoryRepository.GetAllASync();

            var response = new List<CategoryDto>();
            // Map Domain model to DTO
            foreach (var category in categories)
            {
                response.Add(new CategoryDto { 
                    Id = category.id,
                    Description = category.Description,
                    UrlHandle = category.UrlHandle,
                });
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            //Map DTO to Domain Model

            var category = new Category
            {
                Description = request.Description,
                UrlHandle = request.UrlHandle,
            };

            await categoryRepository.CreateAsync(category);

            var response = new CategoryDto
            {
                Description = category.Description,
                UrlHandle = category.UrlHandle,
            };

            return Ok(response);

        }
    }
}
