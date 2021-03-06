﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookExchange.Models
{
    public class Conversation
    {
        [Key]
        public int ConversationId   { get; set; }
        public string Subject   { get; set; }
       public int BookId  { get; set; }
        public Book Book   {  get; set; }
        private List<Message> messages = new List<Message>();
        public List<Message> Messages {
            get
            {
                return messages;
            }
        }
    }
}
