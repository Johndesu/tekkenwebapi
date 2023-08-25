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
                    Id = category.Id,
                    Description = category.Description,
                    UrlHandle = category.UrlHandle,
                });
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var existingCategory = await categoryRepository.GetById(id);  

            if (existingCategory != null)
            {
                var response = new CategoryDto
                {
                    Id = existingCategory.Id,
                    Description = existingCategory.Description,
                    UrlHandle = existingCategory.UrlHandle
                };
                return Ok(response);
            } else{ 
                return NotFound(); 
            }
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

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryRequestDto request)
        {
            // Convert DTO to Domain Model
            var category = new Category
            {
                Id = id,
                Description = request.Description,
                UrlHandle = request.UrlHandle
            };

            category = await categoryRepository.UpdateAsync(category);

            if (category == null)
            {
                return NotFound();
            }

            var response = new CategoryDto {
                Id= category.Id,
                Description = category.Description,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await categoryRepository.DeleteAsync(id);

            if(category == null)
            {
                return NotFound();
            }

            //Convert Domain Model to Dto
            var resposne = new CategoryDto
            {
                Id= category.Id,
                Description = category.Description,
                UrlHandle = category.UrlHandle
            };

            return Ok(resposne);
        }
    }
}
