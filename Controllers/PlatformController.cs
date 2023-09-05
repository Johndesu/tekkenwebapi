using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TekkenPortugal.WebApi.Models.Domain;
using TekkenPortugal.WebApi.Models.DTO;
using TekkenPortugal.WebApi.Repositories.Implementation;
using TekkenPortugal.WebApi.Repositories.Interface;

namespace TekkenPortugal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepository platformRepository;

        public PlatformController(IPlatformRepository platformRepository)
        {
            this.platformRepository = platformRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlatforms()
        {
            var platforms = await platformRepository.GetAllASync();

            var response = new List<PlatformDto>();

            foreach (var platform in platforms)
            {
                response.Add(new PlatformDto
                {
                    Id = platform.Id,
                    Description = platform.Description,
                    Icon = platform.Icon,
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetPlatformById(int id)
        {
            var existingPlatform = await platformRepository.GetById(id);

            if (existingPlatform == null) return NotFound();

            var response = new PlatformDto
            {
                Id = existingPlatform.Id,
                Description = existingPlatform.Description,
                Icon = existingPlatform.Icon,
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlatform(CreatePlatformRequestDto request)
        {
            //Map DTO to Domain Model

            var platform = new Platform
            {
                Description = request.Description,
                Icon = request.Icon
            };

            await platformRepository.CreateAsync(platform);

            var response = new PlatformDto
            {
                Description = platform.Description,
                Icon = platform.Icon
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdatePlatform(int id, UpdatePlatformRequestDto request)
        {
            // Convert DTO to Domain Model
            var platform = new Platform
            {
                Id = id,
                Description = request.Description,
                Icon = request.Icon
            };

            platform = await platformRepository.UpdateAsync(platform);

            if (platform == null)
            {
                return NotFound();
            }

            var response = new PlatformDto
            {
                Id = platform.Id,
                Description = platform.Description,
                Icon = platform.Icon
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeletePlatform(int id)
        {
            var platform = await platformRepository.DeleteAsync(id);

            if (platform == null)
            {
                return NotFound();
            }

            //Convert Domain Model to Dto
            var response = new PlatformDto
            {
                Id = platform.Id,
                Description = platform.Description,
                Icon = platform.Icon
            };

            return NoContent();
        }
    }
}
