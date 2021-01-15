using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;

namespace Library.Controllers
{
    public class DelaysController : Controller
    {
        private readonly LibraryContext _context;

        public DelaysController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Delays
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.BookUsers.
                Include(b => b.Book).Include(b => b.User);

            return View(await libraryContext.ToListAsync());
        }

        // GET: Delays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookUser = await _context.BookUsers
                .Include(b => b.Book)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (bookUser == null)
            {
                return NotFound();
            }

            return View(bookUser);
        }

        // GET: Delays/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: Delays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,BookId,LoanDate,ReturnDate")] BookUser bookUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookUser.BookId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", bookUser.UserId);
            return View(bookUser);
        }

        // GET: Delays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookUser = await _context.BookUsers.FindAsync(id);
            if (bookUser == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookUser.BookId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", bookUser.UserId);
            return View(bookUser);
        }

        // POST: Delays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,BookId,LoanDate,ReturnDate")] BookUser bookUser)
        {
            if (id != bookUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookUserExists(bookUser.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookUser.BookId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", bookUser.UserId);
            return View(bookUser);
        }

        // GET: Delays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookUser = await _context.BookUsers
                .Include(b => b.Book)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (bookUser == null)
            {
                return NotFound();
            }

            return View(bookUser);
        }

        // POST: Delays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookUser = await _context.BookUsers.FindAsync(id);
            _context.BookUsers.Remove(bookUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookUserExists(int id)
        {
            return _context.BookUsers.Any(e => e.UserId == id);
        }
    }
}
