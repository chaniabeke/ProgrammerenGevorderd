using BusinessLayer.Models;
using DataLayer.DataAccessObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        [TestCleanup]
        public void TearDown()
        {
            ToolKit.ResetTables();
        }

        [TestMethod]
        public void AddProduct_ShouldAddProduct()
        {
            // Arrange 
            ProductDAO productDAO = new ProductDAO();
            Product product = new Product("Fanta", 2.5m);

            // Act 
            productDAO.AddProduct(product);

            // Assert           
            Product productInDb = productDAO.GetProduct(1);
            productInDb.Should().BeOfType<Product>();
            productInDb.Name.Should().Be("Fanta");
            productInDb.Price.Should().Be(2.5m);
            productInDb.Id.Should().Be(1);
        }


        [TestMethod]
        public void RemoveProduct_ShouldDeleteProductInDb_IfProductExists()
        {
            // Arrange 
            ProductDAO productDAO = new ProductDAO();
            Product product = new Product("Fanta", 2);
            productDAO.AddProduct(product);

            // Act 
            productDAO.RemoveProduct(1);

            // Assert           
            productDAO.GetProduct(1).Should().BeNull();
        }


        [TestMethod]
        public void GetProduct_ShouldReturnCorrectProduct()
        {
            // Arrange 
            ProductDAO productDAO = new ProductDAO();
            Product product1 = new Product("Fanta", 2);
            productDAO.AddProduct(product1);
            Product product2 = new Product("Cola", 2.5m);
            productDAO.AddProduct(product2);
            // Act 
            Product productInDb = productDAO.GetProduct(1);

            // Assert           
            productInDb.Name.Should().Be("Fanta");
            productInDb.Price.Should().Be(2);
            productInDb.Id.Should().Be(1);
            productInDb.Should().NotBeEquivalentTo(product2);
        }

        [TestMethod]
        public void GetProductByName_ShouldReturnCorrectProduct()
        {
            // Arrange 
            ProductDAO productDAO = new ProductDAO();
            Product product1 = new Product("Fanta", 2);
            productDAO.AddProduct(product1);
            Product product2 = new Product("Cola", 2.5m);
            productDAO.AddProduct(product2);
            // Act 
            Product productInDb = productDAO.GetProductByName("Fanta");

            // Assert           
            productInDb.Name.Should().Be("Fanta");
            productInDb.Price.Should().Be(2);
            productInDb.Id.Should().Be(1);
            productInDb.Should().NotBeEquivalentTo(product2);
        }


        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            // Arrange 
            ProductDAO productDAO = new ProductDAO();
            Product product1 = new Product("Fanta", 2);
            productDAO.AddProduct(product1);
            Product product2 = new Product("Cola", 2.5m);
            productDAO.AddProduct(product2);
            Product product3 = new Product("Bier", 1.8m);
            productDAO.AddProduct(product3);
            Product product4= new Product("Cava glas", 4);
            productDAO.AddProduct(product4);
            Product product5 = new Product("Koffie", 2);
            productDAO.AddProduct(product5);

            // Act 
            IReadOnlyList<Product> products = productDAO.GetAllProducts();

            // Assert           
            products.Count.Should().Be(5);

            products.First().Name.Should().Be("Fanta");
            products.First().Price.Should().Be(2);
        }
    }
}
