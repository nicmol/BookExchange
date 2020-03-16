using BookExchange.Data;
using BookExchange.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Repositories
{
    public class FakeBookRepository : IBookRepository
    {
        public FakeBookRepository()
        {
          
            AppUser appUser = new AppUser
            {
                Id ="E52B8D8B-0914-4BF0-AC75-C48B1043E3AB",
                FirstName="Misty",
                LastName="Bragg",
                UserName="Misty@test.com"
            };
            Book rain = new Book
            {
                Title="Rain",
                Author="Test Author",
                Format="Paperback",
                PubYear=DateTime.Parse("1/30/1996"),
                ImageUrl="OIP[1].jpg",
                appUser=appUser
            };
            Books.Add(rain);
        }

        public List<Book> Books => throw new NotImplementedException();

        public void AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int bookId)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
        public List<Book> GetMyBooks(string appUserId)
        {
            throw new NotImplementedException();
        }
    }
}
