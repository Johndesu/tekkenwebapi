using Microsoft.AspNetCore.Authorization;
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
    public class TagController : ControllerBase
    {
        private readonly ITagRepository tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await tagRepository.GetAllASync();

            var response = new List<TagDto>();

            foreach (var tag in tags)
            {
                response.Add(new TagDto
                {
                    Id = tag.Id,
                    Description = tag.Description
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetTagById(int id)
        {
            var existingTag = await tagRepository.GetById(id);

            if (existingTag != null)
            {
                var response = new TagDto
                {
                    Id = existingTag.Id,
                    Description = existingTag.Description,
                };
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateTag(CreateTagRequestDto request)
        {
            //Map DTO to Domain Model

            var tag = new Tag
            {
                Description = request.Description,
            };

            await tagRepository.CreateAsync(tag);

            var response = new TagDto
            {
                Description = tag.Description,
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateTag(int id, UpdateTagRequestDto request)
        {
            // Convert DTO to Domain Model
            var tag = new Tag
            {
                Id = id,
                Description = request.Description,
            };

            tag = await tagRepository.UpdateAsync(tag);

            if (tag == null)
            {
                return NotFound();
            }

            var response = new TagDto
            {
                Id = tag.Id,
                Description = tag.Description,
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var tag = await tagRepository.DeleteAsync(id);

            if (tag == null)
            {
                return NotFound();
            }

            //Convert Domain Model to Dto
            var response = new TagDto
            {
                Id = tag.Id,
                Description = tag.Description,
            };

            return Ok(response);
        }
    }
}
