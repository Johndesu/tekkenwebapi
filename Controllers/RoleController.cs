using Microsoft.AspNetCore.Mvc;
using TekkenPortugal.WebApi.Data;
using TekkenPortugal.WebApi.Models.Domain;
using TekkenPortugal.WebApi.Models.DTO;
using TekkenPortugal.WebApi.Repositories.Interface;

namespace TekkenPortugal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await roleRepository.GetAllASync();

            var response = new List<RoleDto>();

            foreach (var role in roles)
            {
                response.Add(new RoleDto {
                    Id = role.Id,
                    Description = role.Description
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var existingRole = await roleRepository.GetById(id);

            

            if (existingRole != null)
            {
                var response = new RoleDto
                {
                    Id = existingRole.Id,
                    Description = existingRole.Description,
                };
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleRequestDto request)
        {
            //Map DTO to Domain Model

            var role = new Role
            {
                Description = request.Description,
            };

            await roleRepository.CreateAsync(role);

            var response = new RoleDto
            {
                Description = role.Description,
            };

            return Ok(response);

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateRole(int id, UpdateRoleRequestDto request)
        {
            // Convert DTO to Domain Model
            var role = new Role
            {
                Id = id,
                Description = request.Description,
            };

            role = await roleRepository.UpdateAsync(role);

            if (role == null)
            {
                return NotFound();
            }

            var response = new RoleDto
            {
                Id = role.Id,
                Description = role.Description,
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await roleRepository.DeleteAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            //Convert Domain Model to Dto
            var resposne = new RoleDto
            {
                Id = role.Id,
                Description = role.Description,
            };

            return Ok(resposne);
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        //{
        //    try
        //    {
        //        var roles = await _context.Roles
        //            .Where(role => !role.IsDeleted)
        //            .Select(role => new { role.Id, role.Description })
        //            .OrderBy(role => role.Description)
        //            .ToListAsync();
        //        return Ok(roles);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception and return an error response
        //        return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching roles.");
        //    }
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Role>> GetRoleById(int id)
        //{
        //    try
        //    {
        //        var role = await _context.Roles
        //            .Where(role => role.Id == id && !role.IsDeleted)
        //            .Select(role => new { role.Id, role.Description })
        //            .SingleOrDefaultAsync();

        //        if (role == null)
        //        {
        //            return NotFound(); // Return 404 Not Found if the role with the specified ID is not found
        //        }

        //        return Ok(role);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception and return an error response
        //        return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the role.");
        //    }
        //}
    }
}
