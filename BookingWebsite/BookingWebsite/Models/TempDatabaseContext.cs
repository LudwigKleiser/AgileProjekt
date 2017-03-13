using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookingWebsite.Models.Entities
{
    public partial class TempDatabaseContext
    {
        public TempDatabaseContext(DbContextOptions<TempDatabaseContext> options)
            : base(options)
        {
        }

        public void AddCustomer(CustomersCreateVM customer)
        {
            var customerToAdd = new Customer
            {
                Adress = customer.Adress,
                Email = customer.Email,
                HomeNumber = customer.HomeNumber,
                MobileNumber = customer.MobileNumber,
                Name = customer.Name,
                Password = customer.Password,
                SocialSecurityNumber = customer.SocialSecurityNumber
            };

            Customer.Add(customerToAdd);
            SaveChanges();
        }

        public Customer[] GetCustomersForIndex()
        {
            return this.Customer.Where(o => o.Name == "Ludde").ToArray();
        }
    }
}
