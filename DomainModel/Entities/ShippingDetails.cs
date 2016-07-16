using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Enter your first name")]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter your last name")]
        [MinLength(2)]
        public string LastName { get; set; }


        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter your city")]
        [MinLength(2)]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter your email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Invalid email")]
        public string Email { get; set; }

    }
}
