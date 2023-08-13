using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TekkenPortugal.WebApi.Data;
using TekkenPortugal.WebApi.Models;

namespace TekkenPortugal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly DataContext _context;

        public RoleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            try
            {
                var roles = await _context.Roles
                    .Where(role => !role.IsDeleted)
                    .Select(role => new { role.Id, role.Description })
                    .OrderBy(role => role.Description)
                    .ToListAsync();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                // Log the exception and return an error response
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching roles.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRoleById(int id)
        {
            try
            {
                var role = await _context.Roles
                    .Where(role => role.Id == id && !role.IsDeleted)
                    .Select(role => new { role.Id, role.Description })
                    .SingleOrDefaultAsync();

                if (role == null)
                {
                    return NotFound(); // Return 404 Not Found if the role with the specified ID is not found
                }

                return Ok(role);
            }
            catch (Exception ex)
            {
                // Log the exception and return an error response
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the role.");
            }
        }
    }
}
