using BusinessLayer.Models;
using CustomerOrderRESTService.BusinessLayer.Exceptions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Tests.Models
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void CreateProductObject_ShouldBeOfTypeProduct_IfPropertiesAreCorrect()
        {
            Product product = new Product("Coca-Cola", 1.5m);
            product.Should().BeOfType<Product>();
        }
        [TestMethod]
        public void CreateProductObject_ShouldHaveCorrectProperties_IfPropertiesAreCorrect()
        {
            Product product = new Product("Coca-Cola", 1.5m);
            product.Name.Should().Be("Coca-Cola");
            product.Price.Should().Be(1.5m);
        }
        [TestMethod]
        public void CreateProductObject_ShouldThrowException_IfNameIsNull()
        {
            Action act = () =>
            {
                Product product = new Product(null, 1.5m);
            };
            act.Should().Throw<ArgumentNullException>();
        }
        [TestMethod]
        public void CreateProductObject_ShouldThrowException_IfNameIsEmpty()
        {
            Action act = () =>
            {
                Product product = new Product("", 1.5m);
            };
            act.Should().Throw<BusinessException>().WithMessage("name can't be empty");
        }
        [TestMethod]
        public void CreateProductObject_ShouldThrowException_IfPriceIsBelowZero()
        {
            Action act = () =>
            {
                Product product = new Product("Coca-Cola", -1.5m);
            };
            act.Should().Throw<BusinessException>().WithMessage("price can't be less or equal to 0");
        }
        [TestMethod]
        public void CreateProductObject_ShouldThrowException_IfPriceIsEqualToZero()
        {
            Action act = () =>
            {
                Product product = new Product("Coca-Cola", 0);
            };
            act.Should().Throw<BusinessException>().WithMessage("price can't be less or equal to 0");
        }
        [TestMethod]
        public void SetName_ShouldChangeName_IfNameIsCorrect()
        {
            Product product = new Product("Coca-Cola", 1.5m);
            product.Name = "Fanta";
            product.Name.Should().Be("Fanta");
        }
        [TestMethod]
        public void SetName_ShouldThrowException_IfNameIsNull()
        {
            Product product = new Product("Coca-Cola", 1.5m);
            Action act = () =>
            {
                product.Name = null;
            };
            act.Should().Throw<ArgumentNullException>();
        }
        [TestMethod]
        public void SetName_ShouldThrowException_IfNameIsEmpty()
        {
            Product product = new Product("Coca-Cola", 1.5m);
            Action act = () =>
            {
                product.Name = "";
            };
            act.Should().Throw<BusinessException>().WithMessage("name can't be empty");
        }
        [TestMethod]
        public void SetPrice_ShouldChangePrice_IfPriceIsCorrect()
        {
            Product product = new Product("Coca-Cola", 1.5m);
            product.Price = 2;
            product.Price.Should().Be(2);
        }
        [TestMethod]
        public void SetPrice_ShouldThrowException_IfPriceIsBelowZero()
        {
            Product product = new Product("Coca-Cola", 1.5m);
            Action act = () =>
            {
                product.Price = -1.5m;
            };
            act.Should().Throw<BusinessException>().WithMessage("price can't be less or equal to 0");
        }
        [TestMethod]
        public void SetPrice_ShouldThrowException_IfPriceIsEqualToZero()
        {
            Product product = new Product("Coca-Cola", 1.5m);
            Action act = () =>
            {
                product.Price = 0m;
            };
            act.Should().Throw<BusinessException>().WithMessage("price can't be less or equal to 0");
        }
    }
}
