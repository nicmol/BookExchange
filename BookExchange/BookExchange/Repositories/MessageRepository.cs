using BookExchange.Data;
using BookExchange.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public MessageRepository(ApplicationDbContext context)
        {
             _context=context;
        }
        private readonly ApplicationDbContext _context;
        public List<Message> Messages
        {
            get
            {
                return _context.Messages.Include(c => c.Sender).ToList();
            }
        }

        public void AddMessageToConversation(Message message, Conversation conversation)
        {
            conversation.Messages.Add(message);
            _context.SaveChanges();
        }

        public void Delete(Message message)
        {
            _context.Messages.Remove(message);
        }

        public int Edit(Message message)
        {
            throw new NotImplementedException();
        }

        public Message getMessageById(int messageId)
        {
            Message message = Messages.Find(m => m.MessageId==messageId);
            return message;
        }
    }
}
