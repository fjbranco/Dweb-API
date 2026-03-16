using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using API.Models.ViewModels;

namespace API.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        /// <summary>
        /// Referencia à base de dados
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// construtor do controller
        /// </summary>
        /// <param name="context"></param>
        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            /* _context.Categories.ToListAsync() é um comando LINQ que significa
             *     SELECT *
             *     FROM Categories
             */

            //return await _context.Categories.ToListAsync();
            return await _context.Categories
                                 .Select(c => new CategoryDTO
                                 {
                                     Id = c.Id,
                                     Name = c.Name
                                 })
                                 .OrderBy(c => c.Name)
                                 .ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategorySimplerDTO>> GetCategory(int id)
        {
            //var category = await _context.Categories.FindAsync(id);
            /*
             * in LINQ _context.Categories.FindAsync(id) means
             *     SELECT *
             *     FROM Categories
             *     WHERE Id=id
             */
            var category = await _context.Categories
                                         .Where(c => c.Id == id)
                                         .Select(c => new CategorySimplerDTO
                                         {
                                             Name = c.Name
                                         })
                                         .FirstOrDefaultAsync();
            // protecção quando não há valor a apresentar
            if (category == null)
            {
                return NotFound();
            }

            return category;

        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
