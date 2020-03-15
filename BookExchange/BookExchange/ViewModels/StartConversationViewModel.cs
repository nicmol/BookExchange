using BookExchange.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.ViewModels
{
    public class StartConversationViewModel
    {
        [Required]
        public Message Message
        {
            get; set;
        }
        [Required]
        public String Subject
        {
            get; set;
        }

    }
}
