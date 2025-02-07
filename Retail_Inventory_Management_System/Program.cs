using System;

namespace Retail_Inventory_Management_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Declare and Initialize InventoryManager
            InventoryManager inventoryManager = new InventoryManager();

            while (true)
            {
                Console.WriteLine("Retail Inventory Management System");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("(a) Add New Product");
                Console.WriteLine("(b) Update Existing Product");
                Console.WriteLine("(c) Remove Existing Product");
                Console.WriteLine("(d) List All Products");
                Console.WriteLine("(e) Get Total Value");
                Console.WriteLine("(f) Exit");
                Console.WriteLine("======================================");
                Console.Write("Enter choice: ");
                string? choice = Console.ReadLine()?.ToLower();

                // Maps each valid choice to a specific case
                switch (choice)
                {
                    // This asks the name, quantity, and price for the new product
                    // It uses input + validator methods to get the valid values
                    // It then calls AddProduct method to add the newly created product
                    case "a":
                        string name = GetValidString("Enter Name: ");
                        uint quantity = GetValidUint("Enter Quantity In Stock: ");
                        decimal price = GetValidPrice("Enter Price: ");

                        inventoryManager.AddProduct(new Product(name, quantity, price));
                        Console.WriteLine("Product added successfully!");
                        break;

                    // This asks the id and new quantity for the existing product
                    // It uses input + validator methods to get the valid values
                    // It then calls the UpdateProduct method to update the quantity of the product
                    case "b":
                        uint productIdToUpdate = GetValidUint("Enter Product ID to update: ");
                        uint newQuantity = GetValidUint("Enter new quantity: ");

                        inventoryManager.UpdateProduct(productIdToUpdate, newQuantity);
                        Console.WriteLine("Product updated successfully!");
                        break;

                    // This removes the existing product from the inventory using the product id
                    case "c":
                        uint productIdToRemove = GetValidUint("Enter Product ID to remove: ");

                        inventoryManager.RemoveProduct(productIdToRemove);
                        Console.WriteLine("Product removed successfully!");
                        break;

                    // This calls the ListProducts method to display the current products from the inventory
                    case "d":
                        inventoryManager.ListProducts();
                        break;
                    
                    // This calls the GetTotalValue which will then be displayed to the screen
                    case "e":
                        Console.WriteLine($"Total Inventory Value: {inventoryManager.GetTotalValue()}");
                        break;

                    // This is used to exit the program
                    case "f":
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        break;
                }

                // Do not clear content immediately
                // Wait for user input
                Console.WriteLine("Press any key to go back to the menu...");
                Console.ReadKey();

                // Clear Console at the end
                Console.Clear();
            }
        }


        // Input + Validator methods

        // This method ask for the input then try to parse if it is a valid uint value
        private static uint GetValidUint(string prompt)
        {
            uint value;
            while (true)
            {
                Console.Write(prompt);
                if (uint.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                Console.Clear();
                Console.WriteLine("Invalid input. Please enter a valid number. (non-negative integer)");
            }
        }

        // This method ask for the input then checks if the input is a valid string (this is not null or empty)
        private static string GetValidString(string prompt)
        {
            string? value;
            while (true)
            {
                Console.Write(prompt);
                value = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(value))
                {
                    return value;
                }
                Console.Clear();
                Console.WriteLine("Invalid input. Please enter a valid string.");
            }
        }

        // This method ask for the input then try to parse if it is a valid decimal value
        // This also checks if the value is non-negative
        private static decimal GetValidPrice(string prompt)
        {
            decimal value;
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out value))
                {
                    if (value >= 0)
                        return value;
                }
                Console.Clear();
                Console.WriteLine("Invalid input. Please enter a valid price (non-negative real number).");
            }
        }
    }
}
