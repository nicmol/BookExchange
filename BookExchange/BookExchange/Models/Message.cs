using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace BookExchange.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

       public int ConversationId
        {
            get; set;
        }
        
     
        [StringLength(1000, MinimumLength = 15)]
        public string MessageText { get; set; }
        
      
        public AppUser Sender { get; set; }
        public DateTime Date { get; set; } 

  
        
    }
}
