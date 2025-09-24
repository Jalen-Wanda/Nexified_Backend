﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CampusService
{
    public class Service1 : IService1
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public int AddProduct(Product p)
        {
            try
            {
                db.Products.InsertOnSubmit(p);
                db.SubmitChanges();
                return 0;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return -1;
            }
        }

        public Product GetProduct(int id)
        {
            var product = (from p in db.Products where p.Id.Equals(id) select p).FirstOrDefault();
            return product;
        }

        public List<Product> GetProducts()
        {
            try
            {
                var products = (from p in db.Products where p.active == 1 select p).ToList();
                return products;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting products: " + ex.Message);
                return new List<Product>();
            }
        }

        public User getUser(string password, string email)
        {
            var user = (from u in db.Users
                        where u.password == password && u.email == email
                        select u).FirstOrDefault();

            if (user == null) return null;

            return new User
            {
                Id = user.Id,
                name = user.name,
                email = user.email,
                password = user.password
            };
        }

        public Product GetProductByUserEmail(string email)
        {
            var user = (from u in db.Users where u.email.Equals(email) select u).FirstOrDefault();
            if (user == null) return null;

            var product = (from p in db.Products where p.userId.Equals(user.Id) select p).FirstOrDefault();
            return product;
        }

        public int Login(string email, string password)
        {
            try
            {
                var user = (from u in db.Users where email == u.email && password == u.password select u).FirstOrDefault();

                if (user == null) return 0;
                else return 1;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return -1;
            }
        }

        public int Register(User argUser)
        {
            var user = (from u in db.Users where u.email.Equals(argUser.email) select u).FirstOrDefault();

            try
            {
                if (user != null) return 1;
                else
                {
                    db.Users.InsertOnSubmit(argUser);
                    db.SubmitChanges();
                    return 0;
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return -1;
            }
        }

        // NEW METHODS FOR ADDITIONAL FUNCTIONALITY
        [OperationContract]
        public List<Product> SearchProducts(string searchTerm)
        {
            return (from p in db.Products 
                    where p.name.Contains(searchTerm) || p.description.Contains(searchTerm) 
                    select p).ToList();
        }

        [OperationContract]
        public int UpdateProduct(Product product)
        {
            try
            {
                var existingProduct = (from p in db.Products where p.Id == product.Id select p).FirstOrDefault();
                if (existingProduct != null)
                {
                    existingProduct.name = product.name;
                    existingProduct.price = product.price;
                    existingProduct.category = product.category;
                    existingProduct.description = product.description;
                    existingProduct.quatity = product.quatity;
                    existingProduct.icon = product.icon;
                    db.SubmitChanges();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        [OperationContract]
        public int PlaceBid(int productId, int userId, decimal bidAmount)
        {
            try
            {
                // Check if bid is higher than current price
                var product = (from p in db.Products where p.Id == productId select p).FirstOrDefault();
                if (product == null) return -1;
                
                if (bidAmount <= product.price) return -2; // Bid too low
                
                // Update product price with new bid
                product.price = bidAmount;
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}