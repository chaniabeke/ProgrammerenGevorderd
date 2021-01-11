using BusinessLayer.Managers;
using BusinessLayer.Models;
using CommonLayer;
using System;

namespace KlantBestellingen.WPF
{
    public static class Context
    {
        #region Properties
        public static CustomerManager CustomerManager { get; } = ManagerFactory.CreateCustomerManager();
        public static ProductManager ProductManager { get; } = ManagerFactory.CreateProductManager();
        public static OrderManager OrderManager { get; } = ManagerFactory.CreateOrderManager();
        #endregion

        #region Methodes
        public static void Populate()
        {
            Product product1 = new Product("Fanta", 2.5m);
            Product product2 = new Product("Cola", 2.2m);
            Product product3 = new Product("Hamburger", 8m);
            Customer customer = new Customer("Jan Janssens", "Vrijdagmarkt 100 9000 Gent");
            Customer customer2 = new Customer("Bob Janssens", "Vrijdagmarkt 100 9000 Gent");

            CustomerManager.AddCustomer(customer);
            CustomerManager.AddCustomer(customer2);

            Order order = new Order(DateTime.Now, customer2);
            order.AddProduct(product1, 5);
            order.AddProduct(product3, 8);
            order.AddProduct(product2, 6);
            order.IsPayed = true;

            Order order2 = new Order(new DateTime(2020, 05, 05, 05, 05 ,05), customer2);

            OrderManager.AddOrder(order);
            OrderManager.AddOrder(order2);
        }
        #endregion
    }
}