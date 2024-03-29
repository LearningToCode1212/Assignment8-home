﻿using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8.Models
{
    public class ShoppingCart
    {
        [PrimaryKey, AutoIncrement]
        public int CartID { get; set; }
        public int ItemAmount { get; set; }
        public decimal CartTotal { get; set; }
        //public decimal CartItemPrice { get; set; }
        public string NameOfItem { get; set; }
        public string ItemImageCart { get; set;}

        // Foreign Keys
        [ForeignKey(typeof(ShoppingItems))]
        public int ItemID { get; set; } // Dont forget the foreign keys of the names too

        [ForeignKey(typeof(UserProfile))]
        public int Name { get; set; }

        // Relationships
        [OneToOne]
        public UserProfile UserProfile { get; set; }
    }
}
