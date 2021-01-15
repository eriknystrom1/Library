using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookExamplesController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BookExamplesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/BookExamples
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookExample>>> GetBookExamples()
        {
            return await _context.BookExamples.ToListAsync();
        }

        // GET: api/BookExamples/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookExample>> GetBookExample(int id)
        {
            var bookExample = await _context.BookExamples.FindAsync(id);

            if (bookExample == null)
            {
                return NotFound();
            }

            return bookExample;
        }

        // PUT: api/BookExamples/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookExample(int id, BookExample bookExample)
        {
            if (id != bookExample.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookExample).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExampleExists(id))
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

        // POST: api/BookExamples
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookExample>> PostBookExample(BookExample bookExample)
        {
            _context.BookExamples.Add(bookExample);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookExample", new { id = bookExample.Id }, bookExample);
        }

        // DELETE: api/BookExamples/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookExample>> DeleteBookExample(int id)
        {
            var bookExample = await _context.BookExamples.FindAsync(id);
            if (bookExample == null)
            {
                return NotFound();
            }

            _context.BookExamples.Remove(bookExample);
            await _context.SaveChangesAsync();

            return bookExample;
        }

        private bool BookExampleExists(int id)
        {
            return _context.BookExamples.Any(e => e.Id == id);
        }
    }
}
