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
                FirstName = customer.FirstName,
                Email = customer.Email,
                

            };
            Customer.Add(customerToAdd);
            SaveChanges();

            var userToAdd = new User
            {
                CustomerId = Customer.Single(i => i.Email == customer.Email).CustomerId,
                Password = customer.Password,
                Username = customer.UserName
            };
            User.Add(userToAdd);
            SaveChanges();
           
        }

        public Customer[] GetCustomersForIndex()
        {
            return this.Customer.Where(o => o.FirstName == "Ludde").ToArray();
        }
    }
}
