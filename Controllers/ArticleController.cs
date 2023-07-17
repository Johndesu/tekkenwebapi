using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TekkenPortugal.WebApi.Data;

namespace TekkenPortugal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly DataContext _context;

        public ArticleController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Article>>> GetArticle()
        {
            return Ok(await _context.Article.ToListAsync());
        }
    }
}
