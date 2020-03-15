using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookExchange.Models;
using BookExchange.Repositories;
using BookExchange.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookExchange.Controllers
{
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;      
        IMessageRepository repo; //= new FakeMessageRepository();
        IConversationRepository convoRepo;
        IBookRepository bookRepo;
        
        public MessageController(UserManager<AppUser> userManager,
                                SignInManager<AppUser> signInManager, 
                                IMessageRepository r, IConversationRepository cr, IBookRepository br)
        {
            _userManager=userManager;
            _signInManager=signInManager;
             repo=r;
            convoRepo = cr;
            bookRepo = br;
        }

        //[Authorize(Roles = "Admins, Members")]
        public IActionResult StartConversation()
        {
            return View();
        }

        [HttpPost]
        public async Task<RedirectToActionResult> StartConversation(StartConversationViewModel viewModel, int id)
        {
            if (ModelState.IsValid)
            {
                string username = User.Identity.Name;
                AppUser user = await _userManager.FindByNameAsync(username);
                Message message = new Message();
                message.MessageText = viewModel.Message.MessageText;
                message.Sender=user;
                message.Date=DateTime.Now;
                Conversation conversation = convoRepo.AddConversation(bookRepo.GetBookById(id), viewModel.Subject);
                repo.AddMessageToConversation(message, conversation);
                return RedirectToAction("Conversation", new {id = conversation.CoversationId});
            }
            return RedirectToAction("StartConversation");
        }
        public IActionResult Conversation(int id)
        {
            Conversation conversation = convoRepo.GetConversationById(id);
            return View(conversation);
        }

    }
}