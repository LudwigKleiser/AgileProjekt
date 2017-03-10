using System;
using System.Collections.Generic;

namespace BookingWebsite.Models.Entities
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HomeNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Password { get; set; }
    }
}
