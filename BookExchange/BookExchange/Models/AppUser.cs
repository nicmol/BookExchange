using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Models
{
    public class AppUser: IdentityUser
    {
        public AppUser()
        {
            //sets new user image to default image
            if (ImageUrl == null)
            {
                ImageUrl = "";
            }
        }
        [Required(ErrorMessage = "You must enter a name")]
        public string FullName {get; set; }

        public string ImageUrl { get; set; }
    }


}

