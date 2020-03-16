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
            //sets user image to default image
            if (ImageUrl == null)
            {
                ImageUrl ="/Images/OIPBW8RL1UB.jpg";
            }
        }
        [Required(ErrorMessage = "You must enter a first name")]
        public String FirstName {get; set; }
        
        [Required(ErrorMessage = "You must enter a last name")]
        public String LastName { get; set; }

        public String ImageUrl { get; set; }

        public ICollection<Book> Books { get; set; }

        public String FullName { get { return FirstName + " " + LastName; } }

        public static implicit operator AppUser(string v)
        {
            throw new NotImplementedException();
        }
    }


}

