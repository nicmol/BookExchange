using BookExchange.Data;
using BookExchange.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Repositories
{
    public class BookRepository
    {
    //    public BookRepository(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }
    //    private readonly ApplicationDbContext _context;

    //    public List<Book> Books
    //    {
    //        get
    //        {
    //            return _context.Books.Include(b => b.appUser);
    //        }
    //    }

    //    public void AddBook(Book Book)
    //    {
    //        _context.Books.Add(Book);
    //        _context.SaveChanges();
    //    }

    //    public void AddReplyToBook(AppUser user, string BookText, int BookId)
    //    {

    //        Reply reply = new Reply();
    //        reply.BookText = BookText;
    //        reply.Sender = user;
    //        reply.Date = DateTime.Now;

    //        _context.Books.Find(BookId).Replies.Add(reply);

    //        _context.SaveChanges();
    //    }

    //    public Book getBookByDate(DateTime date)
    //    {
    //        Book Book = Books.FirstOrDefault(m => m.Date.ToString() == date.ToString());
    //        return Book;
    //    }

    //    public Book getBookById(int BookId)
    //    {
    //        Book Book = Books.Find(m => m.BookId == BookId);
    //        return Book;
    //    }

    //    public void AddReplyToBook(string firstName, string lastName, string email, string BookText, string BookDate)
    //    {
    //        throw new NotImplementedException();
    //    }
    }
}
