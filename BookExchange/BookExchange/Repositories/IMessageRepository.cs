using BookExchange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Repositories
{
    public interface IMessageRepository
    {
        List<Message> Messages  {  get; }
        void AddMessageToConversation(Message message, Conversation conversation);
        Message getMessageById(int messageId);

        int Edit(Message message);

        void Delete(Message message);
    }
}
