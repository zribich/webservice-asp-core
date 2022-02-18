using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        //GET:api/Articles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
        {
            return await _context.Article.ToListAsync();

        }
        //GET:api/Articles/0001
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
        [HttpPost]
        public async Task<ActionResult<Article>> PostArticles( Article article)
        {
            _context.Article.Add(article);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArticles) , new {codart=article.codart }, article);

        }
        [HttpPut("{id}") ]
        public async Task<IActionResult> PutArticles(string id, Article article)
        {
            if (id != article.codart )
            {
                return BadRequest();
            }
            _context.Entry(article).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException )
            {  if(!articlesExists(id) )
                {
                    return NotFound();
                }
            else
                {
                    throw;
                }
                
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticles(string id)
        {
            var article = await _context.Article.FindAsync(id);
            if(article == null)
            {
                return NotFound();
            }
            _context.Article.Remove(article);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool articlesExists(string id)
        {
            return _context.Article.Any(e => e.codart == id);
        }
    }
}
