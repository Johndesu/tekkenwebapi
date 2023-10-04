using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TekkenPortugal.WebApi.Models.Domain;
using TekkenPortugal.WebApi.Models.DTO;
using TekkenPortugal.WebApi.Repositories.Interface;

namespace TekkenPortugal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository memberRepository;

        public MemberController(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            var members = await memberRepository.GetAllASync();

            var response = new List<MemberDto>();

            foreach (var member in members)
            {
                response.Add(new MemberDto
                {
                    Id = member.Id,
                    Nickname = member.Nickname,
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    SocialMedia = member.SocialMedia != null ? JsonConvert.DeserializeObject<SocialMediaDto>(member.SocialMedia) : null,
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMemberById(int id)
        {
            var existingMember = await memberRepository.GetById(id);

            if (existingMember == null) return NotFound();

            var response = new MemberDto
            {
                Id = existingMember.Id,
                Nickname = existingMember.Nickname,
                FirstName = existingMember.FirstName,
                LastName = existingMember.LastName,
                SocialMedia = existingMember.SocialMedia != null ? JsonConvert.DeserializeObject<SocialMediaDto>(existingMember.SocialMedia) : null,
            };
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateMember(CreateMemberRequestDto request)
        {
            //Map DTO to Domain Model

            var member = new Member
            {
                Nickname = request.Nickname,
                FirstName = request.FirstName,
                LastName = request.LastName,
                SocialMedia = JsonConvert.SerializeObject(request.SocialMedia),
            };

            await memberRepository.CreateAsync(member);
            
            var response = new MemberDto
            {
                Nickname = member.Nickname,
                FirstName = member.FirstName,
                LastName = member.LastName,
                SocialMedia = member.SocialMedia != null ? JsonConvert.DeserializeObject<SocialMediaDto>(member.SocialMedia) : null,
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateMember(int id, UpdateMemberRequestDto request)
        {
            // Convert DTO to Domain Model
            var member = new Member
            {
                Id = id,
                Nickname = request.Nickname,
                FirstName = request.FirstName,
                LastName = request.LastName,
                SocialMedia = JsonConvert.SerializeObject(request.SocialMedia),
            };

            member = await memberRepository.UpdateAsync(member);

            if (member == null)
            {
                return NotFound();
            }

            var response = new MemberDto
            {
                Id = member.Id,
                Nickname = member.Nickname,
                FirstName = member.FirstName,
                LastName = member.LastName,
                SocialMedia = member.SocialMedia != null ? JsonConvert.DeserializeObject<SocialMediaDto>(member.SocialMedia) : null,
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = await memberRepository.DeleteAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            //Convert Domain Model to Dto
            var response = new MemberDto
            {
                Id = member.Id,
                Nickname = member.Nickname,
                FirstName = member.FirstName,
                LastName = member.LastName,
                SocialMedia = member.SocialMedia != null ? JsonConvert.DeserializeObject<SocialMediaDto>(member.SocialMedia) : null,
            };

            return NoContent();
        }
    }
}
