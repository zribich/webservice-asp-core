using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication11.data;

namespace WebApplication11.Controllers
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticles(string id)
        {
            var Article = await _context.Article.FindAsync(id);
            if (Article == null)
            {
                return NotFound();
            }
            return Article;
        }
    }
}
