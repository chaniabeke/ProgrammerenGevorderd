using BusinessLayer.Models;
using DataLayer.DataAccessObjects;
using DataLayer.Tests.Utils;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
    }
}
