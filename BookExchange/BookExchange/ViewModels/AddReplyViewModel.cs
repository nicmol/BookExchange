using BookExchange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.ViewModels
{
    public class AddReplyViewModel
    {
        public Conversation Conversation { get; set; }

        public Message Message  { get; set; }
    }
}
