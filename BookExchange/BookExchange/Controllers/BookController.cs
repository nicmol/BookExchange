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
using BookExchange.Repositories;

namespace BookExchange.Controllers
{

    public class BookController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
       //private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
                IBookRepository repo; //= new FakeMessageRepository();
       

        public BookController(UserManager<AppUser> userManager,
                                SignInManager<AppUser> signInManager, IWebHostEnvironment webHostEnvironment,
                                IBookRepository r)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
            repo = r;
            
        }

    // GET: Book
    [Authorize]
        public IActionResult Index()
        {
            return View(repo.Books);
        }

        // GET: Book/Details/5
        public IActionResult Details(int id)
        {
            var book = repo.GetBookById(id);
               
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

            var books = repo.GetMyBooks(currentUserId);
            return View(books);

        }

        // GET: Book/Create
        public IActionResult Create()
        {
            //ViewData["appUserId"] = new SelectList(_context.Set<AppUser>(), "Id", "Id");
            return View();
        }

        // POST: Book/Create
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.Photo != null)
                {
                   string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Uploads");
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
                repo.AddBook(book);
                return RedirectToAction(nameof(Index));
            }                       
            return View(model);
        }

        // GET: Book/Edit
        public IActionResult Edit(int id)
        {
          
            var book = repo.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Book/Edit
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("BookId,Title,Author,Format,PubYear,Condition,ImageUrl")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repo.UpdateBook(book);
                  
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
          
            return View(book);
        }

        // GET: Book/Delete
        public IActionResult Delete(int id)
        {

            var book = repo.GetBookById(id);              
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = repo.GetBookById(id);
            repo.DeleteBook(book);           
            return RedirectToAction(nameof(Index));
        }
        private bool BookExists(int id)
        {
            return repo.Books.Any(e => e.BookId == id);
        }
      
    }
}
