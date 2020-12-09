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
        public void Ctor_ShouldBeOfTypeProduct_IfPropertiesAreValid()
        {
            Product product = new Product("Coca-Cola", 1.5m);
            product.Should().BeOfType<Product>();
        }

        [TestMethod]
        public void Ctor_ShouldHaveCorrectProperties_IfPropertiesAreValid()
        {
            Product product = new Product("Coca-Cola", 1.5m);
            product.Name.Should().Be("Coca-Cola");
            product.Price.Should().Be(1.5m);
        }

        [TestMethod]
        public void Ctor_ShouldThrowException_IfNameIsNull()
        {
            Action act = () =>
            {
                Product product = new Product(null, 1.5m);
            };
            act.Should().Throw<NullReferenceException>();
        }

        [TestMethod]
        public void Ctor_ShouldThrowException_IfNameIsEmpty()
        {
            Action act = () =>
            {
                Product product = new Product("", 1.5m);
            };
            act.Should().Throw<ProductException>().WithMessage("Product name invalid");
        }

        [TestMethod]
        public void Ctor_ShouldThrowException_IfPriceIsNegative()
        {
            Action act = () =>
            {
                Product product = new Product("Coca-Cola", -1.5m);
            };
            act.Should().Throw<ProductException>().WithMessage("Product price invalid");
        }

        [TestMethod]
        public void Ctor_ShouldThrowException_IfPriceIsZero()
        {
            Action act = () =>
            {
                Product product = new Product("Coca-Cola", 0);
            };
            act.Should().Throw<ProductException>().WithMessage("Product price invalid");
        }

        #endregion Ctor

        #region Methodes For Properties

        #region SetName

        [TestMethod]
        public void SetName_ShouldChangeName_IfNameIsCorrect()
        {
            Product product = new Product("Coca-Cola", 1.5m);
            product.SetName("Fanta");
            product.Name.Should().Be("Fanta");
        }

        [TestMethod]
        public void SetName_ShouldThrowException_IfNameIsNull()
        {
            Product product = new Product("Coca-Cola", 1.5m);
            Action act = () =>
            {
                product.SetName(null);
            };
            act.Should().Throw<NullReferenceException>();
        }

        [TestMethod]
        public void SetName_ShouldThrowException_IfNameIsEmpty()
        {
            Product product = new Product("Coca-Cola", 1.5m);
            Action act = () =>
            {
                product.SetName("");
            };
            act.Should().Throw<ProductException>().WithMessage("Product name invalid");
        }

        #endregion SetName

        #region SetPrice

        [TestMethod]
        public void SetPrice_ShouldChangePrice_IfPriceIsValid()
        {
            Product product = new Product("Coca-Cola", 1.5m);
            product.SetPrice(2);
            product.Price.Should().Be(2);
        }

        [TestMethod]
        public void SetPrice_ShouldThrowException_IfPriceIsNegative()
        {
            Product product = new Product("Coca-Cola", 1.5m);
            Action act = () =>
            {
                product.SetPrice(-2);
            };
            act.Should().Throw<ProductException>().WithMessage("Product price invalid");
        }

        [TestMethod]
        public void SetPrice_ShouldThrowException_IfPriceIsZero()
        {
            Product product = new Product("Coca-Cola", 1.5m);
            Action act = () =>
            {
                product.SetPrice(0);
            };
            act.Should().Throw<ProductException>().WithMessage("Product price invalid");
        }

        #endregion SetPrice

        #region SetId

        [TestMethod]
        public void SetId_ShouldBeCorrect_IfIdIsValid()
        {
            Product product = new Product("Coca-Cola", 2);

            product.SetId(1);

            product.Id.Should().Be(1);
        }

        [TestMethod]
        public void SetId_ShouldThrowException_IfIdIsZero()
        {
            Product product = new Product("Coca-Cola", 2);

            Action act = () =>
            {
                product.SetId(0);
            };

            act.Should().Throw<ProductException>().WithMessage("Product id invalid");
        }

        [TestMethod]
        public void SetId_ShouldThrowException_IfIdIsNegative()
        {
            Product product = new Product("Coca-Cola", 2);

            Action act = () =>
            {
                product.SetId(-6);
            };

            act.Should().Throw<ProductException>().WithMessage("Product id invalid");
        }

        #endregion SetId

        #endregion Methodes For Properties
    }
}