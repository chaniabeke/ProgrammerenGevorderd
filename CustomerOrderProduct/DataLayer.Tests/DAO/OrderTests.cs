using BusinessLayer.Models;
using DataLayer.DataAccessObjects;
using DataLayer.Tests.Utils;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Tests.DAO
{
    [TestClass]
    public class OrderTests
    {
        [TestInitialize]
        public void Initialize()
        {
            ToolKit.ResetTables();
        }

        [TestCleanup]
        public void TearDown()
        {
            ToolKit.ResetTables();
        }

        [TestMethod]
        public void AddOrder_ShouldAddOrder()
        {
            // Arrange 
            OrderDAO orderDAO = new OrderDAO();
            DateTime dateTime = new DateTime(2020, 12, 05, 05, 05, 05);
            Order order = new Order(dateTime);
            order.IsPayed = true;

            // Act 
            orderDAO.AddOrder(order);

            // Assert           
            Order orderInDb = orderDAO.GetOrder(1);
            orderInDb.Should().BeOfType<Order>();
            orderInDb.DateTime.Should().Be(dateTime);
            orderInDb.IsPayed.Should().Be(true);
            orderInDb.PriceAlreadyPayed.Should().Be(0);
            orderInDb.Id.Should().Be(1);
        }

        [TestMethod]
        public void AddOrder_ShouldAddOrderWithCustomer()
        {
            // Arrange 
            CustomerDAO customerDAO = new CustomerDAO();
            customerDAO.AddCustomer(new Customer("Jan Jansenss", "Straat 123"));
            Customer customer = customerDAO.GetCustomer(1);
            OrderDAO orderDAO = new OrderDAO();
            DateTime dateTime = new DateTime(2020, 12, 05, 05, 05, 05);
            Order order = new Order(dateTime);
            order.IsPayed = true;
            order.SetCustomer(customer);

            // Act 
            orderDAO.AddOrder(order);

            // Assert           
            Order orderInDb = orderDAO.GetOrder(1);
            orderInDb.Should().BeOfType<Order>();
            orderInDb.DateTime.Should().Be(dateTime);
            orderInDb.IsPayed.Should().Be(true);
            orderInDb.PriceAlreadyPayed.Should().Be(0);
            orderInDb.Id.Should().Be(1);
            orderInDb.Customer.Should().BeEquivalentTo(customer);
        }

        //TODO fix priceAlreadyPayed
        [TestMethod]
        public void AddOrder_ShouldAddOrderWithProducts()
        {
            // Arrange 
            Product product1 = new Product("Fanta", 2.5m);
            Product product2 = new Product("Cola", 2.2m);
            Product product3 = new Product("Hamburger", 8m);
            CustomerDAO customerDAO = new CustomerDAO();
            customerDAO.AddCustomer(new Customer("Jan Jansenss", "Straat 123"));
            Customer customer = customerDAO.GetCustomer(1);
            OrderDAO orderDAO = new OrderDAO();
            DateTime dateTime = new DateTime(2020, 12, 05, 05, 05, 05);
            Order order = new Order(dateTime);
            order.SetCustomer(customer);
            order.AddProduct(product1, 1);
            order.AddProduct(product3, 2);
            order.AddProduct(product2, 3);
            order.IsPayed = true;

            // Act 
            orderDAO.AddOrder(order);

            // Assert           
            Order orderInDb = orderDAO.GetOrder(1);
            orderInDb.Should().BeOfType<Order>();
            orderInDb.DateTime.Should().Be(dateTime);
            orderInDb.IsPayed.Should().Be(true);
            orderInDb.PriceAlreadyPayed.Should().Be(25);
            orderInDb.Id.Should().Be(1);
            orderInDb.Customer.Should().BeEquivalentTo(customer);
            orderInDb.GetProducts().Count.Should().Be(3);

            product1.SetId(1);
            orderInDb.GetProducts().First().Key.Should().BeEquivalentTo(product1);
            orderInDb.GetProducts().First().Value.Should().Be(1);
        }

        [TestMethod]
        public void RemoveOrder_ShouldDeleteOrderWithoutDeletingProductsOrCustomers()
        {
            // Arrange 
            ProductDAO productDAO = new ProductDAO();
            Product product1 = new Product("Fanta", 2.5m);
            Product product2 = new Product("Cola", 2.2m);
            CustomerDAO customerDAO = new CustomerDAO();
            customerDAO.AddCustomer(new Customer("Jan Jansenss", "Straat 123"));
            Customer customer = customerDAO.GetCustomer(1);
            OrderDAO orderDAO = new OrderDAO();
            DateTime dateTime = new DateTime(2020, 12, 05, 05, 05, 05);
            Order order = new Order(dateTime);
            order.SetCustomer(customer);
            order.AddProduct(product1, 1);
            order.AddProduct(product2, 3);
            order.IsPayed = true;
            orderDAO.AddOrder(order);

            // Act 
            orderDAO.RemoveOrder(1);

            // Assert           
            orderDAO.GetOrder(1).Should().BeNull();
            productDAO.GetProduct(1).Should().NotBeNull();
            productDAO.GetProduct(2).Should().NotBeNull();
            customerDAO.GetCustomer(1).Should().NotBeNull();
        }
    }
}
