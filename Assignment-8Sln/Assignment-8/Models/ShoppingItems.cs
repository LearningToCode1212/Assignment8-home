using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8.Models
{
    public class ShoppingItems
    {
        [PrimaryKey, AutoIncrement]
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemDescription { get; set; }
        public string ItemImage { get; set; }
    }
}
