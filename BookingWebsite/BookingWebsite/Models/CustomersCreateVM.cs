using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWebsite.Models
{
    public class CustomersCreateVM
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "*Name required")]
        public string Name { get; set; }

        [Display(Name = "Home Number")]
        [Required(ErrorMessage = "*Home number required")]
        public string HomeNumber { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "*Mobile number required")]
        public string MobileNumber { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "*Address required")]
        public string Adress { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "*Email required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Must be a valid email")]
        public string Email { get; set; }

        [Display(Name = "Social Security Number")]
        [Required(ErrorMessage = "*Social Security number required")]
        public string SocialSecurityNumber { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "*Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
