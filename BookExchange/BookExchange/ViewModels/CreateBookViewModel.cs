using BookExchange.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.ViewModels
{
    public class CreateBookViewModel
    {
       
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

        public IFormFile Photo { get; set; }

       
    }
}
