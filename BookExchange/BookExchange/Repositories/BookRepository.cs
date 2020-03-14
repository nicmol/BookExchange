using BookExchange.Data;
using BookExchange.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Repositories
{
    public class BookRepository : IBookRepository
    {
        public BookRepository(ApplicationDbContext context)
        {
            _context=context;
        }
        private readonly ApplicationDbContext _context;

        public List<Book> Books
        {
            get
            {
                return _context.Books.Include(b => b.appUser).ToList();
            }
        }

        public void AddBook(Book Book)
        {
            _context.Books.Add(Book);
            _context.SaveChanges();
        }


        public Book GetBookById(int bookId)
        {
            Book book = Books.Find(b => b.BookId==bookId);
            return book;
        }

        public void UpdateBook(Book book)
        {
            _context.Update(book);
            _context.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public List<Book> GetMyBooks(string id)
        {
            var books = Books.Where(b => b.appUserId==id).ToList();
            return books;

        }
    }
}
