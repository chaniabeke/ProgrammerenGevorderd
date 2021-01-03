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
    public class CustomerTests
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
        public void AddCustomer_ShouldAddCustomer()
        {
            // Arrange 
            CustomerDAO customerDAO = new CustomerDAO();
            Customer customer = new Customer("Jan Janssens", "Vrijdagsmarkt 100 9000 Gent");

            // Act 
            customerDAO.AddCustomer(customer);

            // Assert           
            Customer customerInDb = customerDAO.GetCustomer(1);
            customerInDb.Should().BeOfType<Customer>();
            customerInDb.Name.Should().Be("Jan Janssens");
            customerInDb.Address.Should().Be("Vrijdagsmarkt 100 9000 Gent");
            customerInDb.Id.Should().Be(1);
        }

        [TestMethod]
        public void AddCustomer_ShouldAddCustomerWithOrders()
        {
            // Arrange 
            CustomerDAO customerDAO = new CustomerDAO();
            Customer customer = new Customer("Jan Janssens", "Vrijdagsmarkt 100 9000 Gent");
            Order order1 = new Order(new DateTime(2020, 5, 10, 20, 0, 0));
            order1.IsPayed = true;
            customer.AddOrder(order1);
            customer.AddOrder(new Order(new DateTime(2020, 5, 5, 20, 0, 0)));

            // Act 
            customerDAO.AddCustomer(customer);

            // Assert           
            Customer customerInDb = customerDAO.GetCustomerWithOrders(1);
            customerInDb.GetOrders().Count.Should().Be(2);
            Order orderInDB = customerInDb.GetOrders().First();
            orderInDB.DateTime.Should().Be(new DateTime(2020, 5, 10, 20, 0, 0));
            orderInDB.IsPayed.Should().BeTrue();
            orderInDB.PriceAlreadyPayed.Should().Be(0);
        }

        [TestMethod]
        public void GetCustomer_ShouldReturnCorrectCustomer()
        {
            // Arrange 
            CustomerDAO customerDAO = new CustomerDAO();
            Customer customer1 = new Customer("Jan Janssens", "Vrijdagsmarkt 100 9000 Gent");
            customerDAO.AddCustomer(customer1);
            Customer customer2 = new Customer("Bob Janssens", "Langestraat 56 8000 Kortrijk");
            customerDAO.AddCustomer(customer2);
            // Act 
            Customer customerInDb = customerDAO.GetCustomer(1);

            // Assert           
            customerInDb.Name.Should().Be("Jan Janssens");
            customerInDb.Address.Should().Be("Vrijdagsmarkt 100 9000 Gent");
            customerInDb.Id.Should().Be(1);
            customerInDb.Should().NotBeEquivalentTo(customer2);
        }

        [TestMethod]
        public void GetAllCustomers_ShouldReturnAllCustomers()
        {
            // Arrange 
            CustomerDAO customerDAO = new CustomerDAO();
            Customer customer1 = new Customer("Jan Janssens", "Vrijdagsmarkt 100 9000 Gent");
            customerDAO.AddCustomer(customer1);
            Customer customer2 = new Customer("Bob Janssens", "Langestraat 56 8000 Kortrijk");
            customerDAO.AddCustomer(customer2);
            Customer customer3 = new Customer("Daan Janssens", "Zeedijk 5 Blankeberge");
            customerDAO.AddCustomer(customer3);

            // Act 
            IReadOnlyList<Customer> customers = customerDAO.GetAllCustomers();

            // Assert           
            customers.Count.Should().Be(3);

            customers.First().Name.Should().Be("Jan Janssens");
            customers.First().Address.Should().Be("Vrijdagsmarkt 100 9000 Gent");
        }

        [TestMethod]
        public void RemoveCustomer_ShouldDeleteCustomerInDb_IfCustomerExists()
        {
            // Arrange 
            CustomerDAO customerDAO = new CustomerDAO();
            Customer customer = new Customer("Jan Janssens", "Vrijdagsmarkt 100 9000 Gent");
            customerDAO.AddCustomer(customer);

            // Act 
            customerDAO.RemoveCustomer(1);

            // Assert           
            customerDAO.GetCustomer(1).Should().BeNull();
        }
    }
}
