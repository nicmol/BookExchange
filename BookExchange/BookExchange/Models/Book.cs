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
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Format { get; set; }
        [Required]
        public DateTime PubYear { get; set; }
        [Required]
        public string Condition { get; set; }

        public string ImageUrl { get; set; }
    }
}
