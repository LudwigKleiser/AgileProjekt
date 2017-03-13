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

        public void AddCustomer(Customer customer)
        {
            Customer.Add(customer);
            SaveChanges();
        }

        public Customer[] GetCustomersForIndex()
        {
            return this.Customer.Where(o => o.Name == "Ludde").ToArray();
        }
    }
}
