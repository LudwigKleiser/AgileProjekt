using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace BookingWebsite.Models.Entities
{
    public partial class HotelASPContext
    {
        public HotelASPContext(DbContextOptions<HotelASPContext> options)
            : base(options)
        {
        }
       
        //public void AddCustomer(CustomersCreateVM customer)
        //{


        //    //var customerToAdd = new Customer
        //    //{
                    
        //    //    FirstName = customer.FirstName,
        //    //    Email = customer.Email,
        //    //    City = customer.City,
        //    //    AddressLine1 = customer.AddressLine1,
        //    //    AddressLine2 = customer.AddressLine2,
        //    //    LastName = customer.LastName,
        //    //    Telephone = customer.Telephone,
        //    //    Mobilephone = customer.Mobilephone,
        //    //    ZipCode = customer.ZipCode,
        //    //    SocialSecurityNumber = customer.SocialSecurityNumber,



        //    //};
        //    //Customer.Add(customerToAdd);

        //    SaveChanges();

        //}

        //public Customer[] GetCustomersForIndex()
        //{
        //    return Customer.ToArray();
        //}

        //public void AddUser(UserCreateVM usr)
        //{
        //    User userToAdd = new User
        //    {
        //        //Customer_Id = Customer.SingleOrDefault(i => i.Email == usr.Email).CustomerId,
        //        Customer_Id = Customer.Single(i => i.Email == usr.Email).CustomerId,


        //    };
        //    User.Add(userToAdd);
        //    SaveChanges();

        //}

        //public Customer FindCustomerById(int id)
        //{
        //    return Customer.SingleOrDefault(i => i.CustomerId == id);
        //}

        //internal void EditCustomer(Customer customer)
        //{
        //    var customerToFind = Customer.Find(customer.CustomerId);
        //    customerToFind.FirstName = customer.FirstName;
        //    customerToFind.LastName = customer.LastName;
        //    customerToFind.Telephone = customer.Telephone;
        //    SaveChanges();
        //}
    }
}
