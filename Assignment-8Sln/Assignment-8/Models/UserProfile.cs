using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8.Models
{
    public class UserProfile
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string Bio { get; set; }

        //Relationships
        [OneToOne]
        public ShoppingCart shoppingCart { get; set; }
    }
}
