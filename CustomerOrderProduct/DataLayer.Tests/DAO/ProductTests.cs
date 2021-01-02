using BusinessLayer.Models;
using DataLayer.DataAccessObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Tests.DAO
{
    [TestClass]
    public class ProductTests
    {
        [TestInitialize]
        public void Initialize()
        {
            ToolKit.ResetTables();
        }

        [TestMethod]
        public void AddProduct_ShouldAddProduct()
        {
            // Arrange 
            ProductDAO productDAO = new ProductDAO();
            Product product = new Product("Fanta", 2);

            // Act 
            productDAO.AddProduct(product);

            // Assert           
            Product productInDb = productDAO.GetProduct(1);
            productInDb.Should().BeOfType<Product>();
            productInDb.Name.Should().Be("Fanta");
            productInDb.Price.Should().Be(2);
            productInDb.Id.Should().Be(1);
        }
    }
}
