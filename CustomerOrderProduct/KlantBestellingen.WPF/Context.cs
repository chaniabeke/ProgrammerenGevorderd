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
            Product product4 = new Product("Braadworst", 5m);
            Product product5 = new Product("Familiemenu XXL", 30m);
            Customer customer = new Customer("Jan Janssens", "Vrijdagmarkt 100 9000 Gent");
            Customer customer2 = new Customer("Bob Janssens", "Vrijdagmarkt 100 9000 Gent");
            Customer customer3 = new Customer("Henrik De Hendriksson", "Nieuwstraat 100 1000 Brussel");

            CustomerManager.AddCustomer(customer);
            CustomerManager.AddCustomer(customer2);
            CustomerManager.AddCustomer(customer3);

            Order order = new Order(DateTime.Now, customer2);
            order.AddProduct(product1, 5);
            order.AddProduct(product3, 8);
            order.AddProduct(product2, 6);
            order.IsPayed = true;

            Order order2 = new Order(new DateTime(2020, 05, 05, 05, 05 ,05), customer2);

            Order order3 = new Order(DateTime.Now, customer3);
            order3.AddProduct(product5, 1);
            order3.AddProduct(product1, 8);
            order3.AddProduct(product4, 2);

            Order order4 = new Order(new DateTime(2020, 10, 10, 10, 00, 55));
            order4.AddProduct(product5, 1);

            OrderManager.AddOrder(order);
            OrderManager.AddOrder(order2);
            OrderManager.AddOrder(order3);
            OrderManager.AddOrder(order4);
        }
        #endregion
    }
}