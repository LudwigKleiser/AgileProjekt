using System;
using System.Collections.Generic;

namespace BookingWebsite.Models.Entities
{
    public partial class User
    {
        public int UserId { get; set; }
        public int Customer_Id { get; set; }
        
        public int? Statuscode { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
