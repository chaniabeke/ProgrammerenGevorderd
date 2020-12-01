using BusinessLayer.Exceptions;
using BusinessLayer.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BusinessLayer.Tests.Models
{
    [TestClass]
    public class ProductTests
    {
        #region Ctor

        [TestMethod]
        public void Ctor_ShouldBeOfTypeProduct_IfPropertiesAreCorrect()
        {
            Product product = new Product("Coca-Cola", 1.5);
            product.Should().BeOfType<Product>();
        }

        [TestMethod]
        public void Ctor_ShouldHaveCorrectProperties_IfPropertiesAreCorrect()
        {
            Product product = new Product("Coca-Cola", 1.5);
            product.Name.Should().Be("Coca-Cola");
            product.Price.Should().Be(1.5);
        }

        [TestMethod]
        public void Ctor_ShouldThrowException_IfNameIsNull()
        {
            Action act = () =>
            {
                Product product = new Product(null, 1.5);
            };
            act.Should().Throw<NullReferenceException>();
        }

        [TestMethod]
        public void Ctor_ShouldThrowException_IfNameIsEmpty()
        {
            Action act = () =>
            {
                Product product = new Product("", 1.5);
            };
            act.Should().Throw<ProductException>().WithMessage("Product name invalid");
        }

        [TestMethod]
        public void Ctor_ShouldThrowException_IfPriceIsBelowZero()
        {
            Action act = () =>
            {
                Product product = new Product("Coca-Cola", -1.5);
            };
            act.Should().Throw<ProductException>().WithMessage("Product price invalid");
        }

        [TestMethod]
        public void Ctor_ShouldThrowException_IfPriceIsEqualToZero()
        {
            Action act = () =>
            {
                Product product = new Product("Coca-Cola", 0);
            };
            act.Should().Throw<ProductException>().WithMessage("Product price invalid");
        }

        #endregion Ctor

        #region SetName

        [TestMethod]
        public void SetName_ShouldChangeName_IfNameIsCorrect()
        {
            Product product = new Product("Coca-Cola", 1.5);
            product.SetName("Fanta");
            product.Name.Should().Be("Fanta");
        }

        [TestMethod]
        public void SetName_ShouldThrowException_IfNameIsNull()
        {
            Product product = new Product("Coca-Cola", 1.5);
            Action act = () =>
            {
                product.SetName(null);
            };
            act.Should().Throw<NullReferenceException>();
        }

        [TestMethod]
        public void SetName_ShouldThrowException_IfNameIsEmpty()
        {
            Product product = new Product("Coca-Cola", 1.5);
            Action act = () =>
            {
                product.SetName("");
            };
            act.Should().Throw<ProductException>().WithMessage("Product name invalid");
        }

        #endregion SetName

        #region SetPrice

        [TestMethod]
        public void SetPrice_ShouldChangePrice_IfPriceIsCorrect()
        {
            Product product = new Product("Coca-Cola", 1.5);
            product.SetPrice(2);
            product.Price.Should().Be(2);
        }

        [TestMethod]
        public void SetPrice_ShouldThrowException_IfPriceIsBelowZero()
        {
            Product product = new Product("Coca-Cola", 1.5);
            Action act = () =>
            {
                product.SetPrice(-2);
            };
            act.Should().Throw<ProductException>().WithMessage("Product price invalid");
        }

        [TestMethod]
        public void SetPrice_ShouldThrowException_IfPriceIsEqualToZero()
        {
            Product product = new Product("Coca-Cola", 1.5);
            Action act = () =>
            {
                product.SetPrice(0);
            };
            act.Should().Throw<ProductException>().WithMessage("Product price invalid");
        }

        #endregion SetPrice
    }
}