using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookExchange.Data;
using BookExchange.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using BookExchange.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace BookExchange.Controllers
{

    public class BookController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(ApplicationDbContext context, UserManager<AppUser> userManager,
                                SignInManager<AppUser> signInManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;

    }

    // GET: Book
    [Authorize]
        public async Task<IActionResult> Index()
        {
            var books = _context.Books.Include(b => b.appUser);
            return View(await books.ToListAsync());

        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.appUser)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        //GET: Book/MyBooks
        public async Task<IActionResult> MyBooks()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var currentUserId = currentUser.Id;
            
            var books = _context.Books.Include(b => b.appUser).Where(b => b.appUserId == currentUserId);
            return View(await books.ToListAsync());

        }

        // GET: Book/Create
        public IActionResult Create()
        {
            ViewData["appUserId"] = new SelectList(_context.Set<AppUser>(), "Id", "Id");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.Photo != null)
                {
                   string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                   uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                   string filePath =  Path.Combine(uploadsFolder, uniqueFileName);
                   model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Book book = new Book
                {
                    Title = model.Title,
                    Author = model.Author,
                    Format = model.Format,
                    PubYear = model.PubYear,
                    Condition = model.Condition,
                    ImageUrl = uniqueFileName
                };
                var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                book.appUserId = currentUser.Id;
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }                       
            return View(model);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["appUserId"] = new SelectList(_context.Set<AppUser>(), "Id", "Id", book.appUserId);
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Title,Author,Format,PubYear,Condition,ImageUrl")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
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
            ViewData["appUserId"] = new SelectList(_context.Set<AppUser>(), "Id", "Id", book.appUserId);
            return View(book);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.appUser)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}
