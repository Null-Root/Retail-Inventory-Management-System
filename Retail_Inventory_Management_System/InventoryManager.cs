using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail_Inventory_Management_System
{
    public class InventoryManager
    {
        // This will contain the products that will be created
        // A Dictionary was chosen for O(1) lookup using id
        private Dictionary<uint, Product> productInventory;

        // This will be used to generate product id
        private uint currentAvailableId = 1;

        public InventoryManager()
        {
            // From the constraints, it is assumed that inventory starts without any products
            productInventory = new Dictionary<uint, Product>();
        }

        // A method that adds a new product to the inventory
        public void AddProduct(Product product)
        {
            // The product id is assigned based on the value of currentAvailableId
            product.ProductId = currentAvailableId;

            // The product object is added to the inventory
            productInventory.Add(product.ProductId, product);

            // It is then incremented for the next product that will require an id
            currentAvailableId++;
        }

        // A method that removes an existing product from the inventory based on the product id
        public void RemoveProduct(uint productId)
        {
            productInventory.Remove(productId);
        }

        // A method that updates an existing product from the inventory based on the product id
        public void UpdateProduct(uint productId, uint newQuantity)
        {
            productInventory[productId].QuantityInStock = newQuantity;
        }

        // A method that displays the products from the inventory
        public void ListProducts()
        {
            // Uses the string builder to accumulate string representation of each product
            StringBuilder productListStrBuilder = new StringBuilder();
            foreach (var kvp in productInventory)
            {
                productListStrBuilder.AppendLine($"ID: {kvp.Key}, Name: {kvp.Value.Name}, Quantity: {kvp.Value.QuantityInStock}, Price: {kvp.Value.Price}");
            }

            // Displays the content of string builder
            Console.WriteLine(productListStrBuilder.ToString());
        }

        // A method that gets the total value of the inventory
        public decimal GetTotalValue()
        {
            return productInventory.Values.Sum(product => product.Price * product.QuantityInStock);
        }
    }
}
