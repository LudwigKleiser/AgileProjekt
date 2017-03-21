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
        public void AddUser(UsersRegisterVM model)
        {
            var userToAdd = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                AspNetUserId = model.AspNetUserId,
                City = model.City,
                ZipCode = model.ZipCode,


            };
            User.Add(userToAdd);

            SaveChanges();
        }

        public User[] GetUsersForIndex()
        {
            return User.ToArray();
        }

        public UsersDetailsVM FindUserById(string id)
        {
            var user = User.Single(i => i.AspNetUserId == id);
            
            var userForDetails = new UsersDetailsVM
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                AddressLine1 = user.AddressLine1,
                AddressLine2 = user.AddressLine2,
                City = user.City,
                ZipCode = user.ZipCode
           };

            return userForDetails;
        }

        public void FindUserForEditByID(string id, UsersEditVM model)
        {
            var user = User.Single(i => i.AspNetUserId == id);
            if (model.FirstName != null) user.FirstName = model.FirstName;
            if (model.LastName != null) user.LastName = model.LastName;
            if (model.AddressLine1 != null) user.AddressLine1 = model.AddressLine1;
            if (model.AddressLine2 != null) user.AddressLine2 = model.AddressLine2;
            if (model.City != null) user.City = model.City;
            if (model.ZipCode != null) user.ZipCode = model.ZipCode;

            SaveChanges();


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
