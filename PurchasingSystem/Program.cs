using PurchasingSystem.Entities;
using PurchasingSystem.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PurchasingSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string clientName = Console.ReadLine();
            Console.Write("Email: ");
            string clientEmail = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime clientBirth = DateTime.Parse(Console.ReadLine());

            Client newClient = new Client(clientName, clientEmail, clientBirth);

            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            string orderStatus = Console.ReadLine();
            Console.Write("How many items to this order? ");
            int orderNItems = int.Parse(Console.ReadLine());

            Enum.TryParse(orderStatus, out OrderStatus orderStatusParsed);

            Order newOrder = new Order(DateTime.Now, orderStatusParsed, newClient);

            for (int i = 1; i <= orderNItems; i++)
            {
                Console.WriteLine($"Enter product data #{i}");
                Console.Write("Enter product name: ");
                string productName = Console.ReadLine();
                Console.Write($"Enter product price: ");
                double productPrice = double.Parse(Console.ReadLine());
                Console.Write("Enter quantity: ");
                int productQty = int.Parse(Console.ReadLine());

                Product newProduct = new Product(productName, productPrice);
                OrderItem newOrderItem = new OrderItem(newProduct, productQty, productPrice);

                newOrder.AddItem(newOrderItem);

            }

            Console.WriteLine(newOrder);


        }
    }
}
