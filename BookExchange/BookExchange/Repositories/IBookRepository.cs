using BookExchange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Repositories
{
    public interface IBookRepository
    {
        List<Book> Books { get; }
        void AddBook(Book book);

        Book GetBookById(int bookId);

        void UpdateBook(Book book);

        void DeleteBook(Book book);
        
    }
    

       
}
