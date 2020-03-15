using BookExchange.Data;
using BookExchange.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        public ConversationRepository(ApplicationDbContext context)
        {
            _context=context;
        }
        private readonly ApplicationDbContext _context;

        public List<Conversation> Conversations
        {
            get
            {
                return _context.Conversations.Include(c => c.Book).Include(c => c.Messages).ThenInclude(m => m.Sender).ToList();
            }
            
        }
            
         

        public List<Conversation> GetConversationsByBook(Book book)
        {
            return Conversations.Where(c => c.BookId==book.BookId).ToList();
            
        }

        public Conversation GetConversationById(int id)
        {
            return Conversations.Find(c => c.ConversationId==id);
        }

        public List<Message> GetMessagesInConversation(int conversationId)
        {
            var messages = GetConversationById(conversationId).Messages;
            return messages;
        }

        public Conversation AddConversation(Book book, String subject)
        {
            Conversation conversation = new Conversation();
            conversation.Book = book;
            conversation.Subject = subject;
            conversation.BookId = book.BookId;
            _context.Conversations.Add(conversation);
            _context.SaveChanges();
            return conversation;
              
        }
        public List<Conversation> GetConversationsByUserId(string id)
        {
            List<Conversation> conversations = _context.Conversations.FromSqlRaw
                    ("SELECT DISTINCT c.* FROM Conversations c JOIN " +
                    "Messages m ON m.ConversationId=c.ConversationId WHERE m.SenderId={0}", id)
                    .Include(c => c.Book).Include(c => c.Messages).ThenInclude(m => m.Sender).ToList();
            
            return conversations;
        }
    }
}
