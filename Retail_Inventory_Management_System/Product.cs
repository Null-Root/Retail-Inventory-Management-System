using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail_Inventory_Management_System
{
    public class Product
    {
        // From the constraints, ProductIDs are positive integers so unsigned integer is used
        public uint ProductId { get; set; }
        
        public string Name { get; set; }

        // From the constraints, QuantityInStock are non-negative integers so unsigned integer is used
        public uint QuantityInStock { get; set; }

        // Decimal was used as data type for high precision since it is about money, the constraint will be applied before creating the price
        public decimal Price { get; set; }

        public Product(string name, uint quantityInStock, decimal price)
        {
            Name = name;
            QuantityInStock = quantityInStock;
            Price = price;
        }
    }
}
