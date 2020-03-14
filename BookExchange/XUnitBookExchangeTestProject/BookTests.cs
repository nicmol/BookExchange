using BookExchange.Controllers;
using BookExchange.Models;
using BookExchange.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using Xunit;

namespace XUnitBookExchangeTestProject
{
    public class BookTests
    {
        
        [Fact]
        public void AddBookTest()
        {
        //    //Arrange
        //    var repo = new FakeBookRepository();
        //    var _userManager= new UserManager<AppUser>();
        //    private readonly SignInManager<AppUser> _signInManager;
        //    private readonly IWebHostEnvironment _webHostEnvironment;
        //    var bookController = new BookController(_userManager, _signInManager, _webHostEnvironment);
        //    var beforeCount = repo.Books.Count;
            
        ////Act
        //    bookController.AddBook("Rain", "Test Author",
        //      "Paperback", DateTime.Parse("1/30/1996"), "OIP[1].jpg", appUser);
        //    //Assert
        //    Assert.Equal(beforeCount+1, repo.Books.Count);

        }
    }
}
