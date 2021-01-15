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
    public class BookUsersController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BookUsersController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/BookUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookUser>>> GetBookUsers()
        {
            return await _context.BookUsers.ToListAsync();
        }

        // GET: api/BookUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookUser>> GetBookUser(int id)
        {
            var bookUser = await _context.BookUsers.FindAsync(id);

            if (bookUser == null)
            {
                return NotFound();
            }

            return bookUser;
        }

        // PUT: api/BookUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookUser(int id, BookUser bookUser)
        {
            if (id != bookUser.UserId)
            {
                return BadRequest();
            }

            _context.Entry(bookUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookUserExists(id))
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

        // POST: api/BookUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookUser>> PostBookUser(BookUser bookUser)
        {
            _context.BookUsers.Add(bookUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookUserExists(bookUser.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookUser", new { id = bookUser.UserId }, bookUser);
        }

        // DELETE: api/BookUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookUser>> DeleteBookUser(int id)
        {
            var bookUser = await _context.BookUsers.FindAsync(id);
            if (bookUser == null)
            {
                return NotFound();
            }

            _context.BookUsers.Remove(bookUser);
            await _context.SaveChangesAsync();

            return bookUser;
        }

        private bool BookUserExists(int id)
        {
            return _context.BookUsers.Any(e => e.UserId == id);
        }
    }
}
