using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Models
{
    public class Book
    {
        
        public int BookId { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public String Author { get; set; }
        [Required]
        public String Format { get; set; }
        
        [Required]
        [DisplayFormat(DataFormatString = "{0:Y}", ApplyFormatInEditMode = true)]
        public DateTime PubYear { get; set; }
        [Required]
        public String Condition { get; set; }

        public String ImageUrl { get; set; }

        public AppUser appUser { get; set; }

        public String appUserId { get; set; }

        private List<Conversation> conversations = new List<Conversation>();
        public List<Conversation> Conversations
        {
            get
            {
                return conversations;
            }

        }

      
    }
}
