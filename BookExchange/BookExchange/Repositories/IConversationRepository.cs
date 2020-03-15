using BookExchange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Repositories
{
    public interface IConversationRepository
    {
        public List<Conversation> Conversations { get; }
        public List<Conversation> GetConversationsByBook(Book book);

        public Conversation GetConversationById(int id);

        public List<Message> GetMessagesInConversation(int conversationId);

        public Conversation AddConversation(Book book, String subject);
            
    }
}
