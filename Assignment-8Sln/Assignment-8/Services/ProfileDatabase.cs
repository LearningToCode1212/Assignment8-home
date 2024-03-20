using Assignment_8.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8.Services
{
    internal class ProfileDatabase
    {
        private SQLiteConnection _dbConnection;
        public string GetDatabasePath()
        {
            string fileName = "profiledatabase.db";
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return pathToDb + fileName;
        }
        public ProfileDatabase()
        {
            _dbConnection = new SQLiteConnection(GetDatabasePath());
            _dbConnection.CreateTable<UserProfile>();
            _dbConnection.CreateTable<ShoppingItems>();
            _dbConnection.CreateTable<ShoppingCart>();
            SeedDatabase();
        }
        public void SeedDatabase()
        {
            if (_dbConnection.Table<UserProfile>().Count() == 0) 
            {
                UserProfile userProfile = new UserProfile()
                {
                    Name = "Ethan",
                    Surname = "Joubert",
                    EmailAddress = "ethanjoubert@gmail.com",
                    Bio = "Testing if this works"
                };
                _dbConnection.Insert(userProfile);
            }

            // Shopping List Items
            if (_dbConnection.Table<ShoppingItems>().Count() == 0) 
            {
                List<ShoppingItems> shoppingItems = new List<ShoppingItems>()
                {
                    new ShoppingItems()
                    {
                        ItemName = "Item",
                        ItemQuantity = 1,
                        ItemPrice = 1,
                        ItemImage = "Air Max.jpg",
                    },
                    new ShoppingItems()
                    {
                        ItemName = "Item 2",
                        ItemQuantity = 2,
                        ItemPrice = 2,
                        ItemImage = "Air Force.jfif",
                    },
                    new ShoppingItems()
                    {
                        ItemName = "Item 3",
                        ItemQuantity = 3,
                        ItemPrice = 3,
                        ItemImage = "CBa.jpg",
                    }
                };
                _dbConnection.InsertAll(shoppingItems);
            }

            // Shopping Cart Items
            if (_dbConnection.Table<ShoppingCart>().Count() == 0)
            {
                List<ShoppingCart> carts = new List<ShoppingCart>()
                {
                    /*new ShoppingCart()
                    {
                        NameOfItem = "Test",
                        ItemAmount = 3,
                        CartTotal = 40
                    }*/
                };
                _dbConnection.InsertAll(carts);
            }
        }


        // Methods
        // User Profile Methods
        public void UpdateUser(UserProfile profile)
        {
            _dbConnection.Update(profile);
        }

        public UserProfile GetUserByID(int id)
        {
            UserProfile user = _dbConnection.Table<UserProfile>().Where(x => x.UserId == id).FirstOrDefault();

            if (user != null)
                _dbConnection.GetChildren(user, true);

            return user;
        }


        // Shopping List Methods
        public List<ShoppingItems> GetAllItems()
        {
            return _dbConnection.Table<ShoppingItems>().ToList();
        }


        // Shopping Cart Methods
        public List<ShoppingCart> GetAllCartItems()
        {
            return _dbConnection.Table<ShoppingCart>().ToList();
        }


        // Insert Item from Shopping List to Cart
        public void InsertToCart(string name, decimal amount, int quantity, string images)
        {
            var newItem = new ShoppingCart
            {
                NameOfItem = name,
                ItemAmount = quantity,
                CartTotal = amount,
                ItemImageCart = images
            };

            if (newItem.NameOfItem == "John Doe")
            {
                
            }
            _dbConnection.Insert(newItem);
        }
        // Display Error Message here..


        // Remove Item From Cart
        public void RemoveFromCart(ShoppingCart itemToRemove)
        {
            _dbConnection.Delete(itemToRemove);
        }
    }
}
