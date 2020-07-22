using PurchasingSystem.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace PurchasingSystem.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }
        

        public Order(DateTime moment, OrderStatus orderStatus, Client client)
        {
            Moment = moment;
            OrderStatus = orderStatus;
            Client = client;
        }
        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double total = 0;
            foreach (var item in Items)
            {
                total += item.Price * item.Quantity;
            }

            return total;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY");
            sb.AppendLine($"Order moment: {Moment}");
            sb.AppendLine($"Order Status: {OrderStatus}");
            sb.AppendLine($"Client: {Client.Name}, {Client.Email}, {Client.BirthDate:dd/MM/yyyy}");
            sb.AppendLine("ORDER ITEMS");

            foreach (var item in Items)
            {
                sb.AppendLine($"{item.Product.Name}, ${item.Product.Price.ToString("F2", CultureInfo.InvariantCulture)}, Quantity: {item.Quantity}, Subtotal: ${item.SubTotal()}");
            }

            sb.AppendLine($"Total Price: {Total().ToString("F2", CultureInfo.InvariantCulture)}");
            return sb.ToString();
        }

    }
}
