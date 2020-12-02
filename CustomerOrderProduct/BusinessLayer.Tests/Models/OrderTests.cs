using BusinessLayer.Exceptions;
using BusinessLayer.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Tests.Models
{
    [TestClass]
    public class OrderTests
    {
        #region Ctor
        [TestMethod]
        public void Ctor_ShouldBeTypeOfOrder_IfPropertiesAreValid()
        {
            DateTime dateTime = new DateTime(2020, 08, 18, 12, 15, 56);
            Customer customer = new Customer("Jan Janssens", "Langemunt 49 9000 Gent");
            Dictionary<Product, int> products = new Dictionary<Product, int>();
            Product product1 = new Product("Cola", 1.5);
            Product product2 = new Product("Fanta", 2);
            products.Add(product1, 5);
            products.Add(product2, 1);

            Order order = new Order(3, customer, dateTime, products);

            order.Should().BeOfType<Order>();
        }

        [TestMethod]
        public void Ctor_ShouldHaveCorrectProperties_IfPropertiesAreValid()
        {
            Dictionary<Product, int> products = new Dictionary<Product, int>();
            Product product1 = new Product("Cola", 1.5);
            Product product2 = new Product("Fanta", 2);
            products.Add(product1, 5);
            products.Add(product2, 1);

            DateTime dateTime = new DateTime(2020, 08, 18, 12, 15, 56);
            Customer customer = new Customer("Jan Janssens", "Langemunt 49 9000 Gent");

            Order order = new Order(3, customer, dateTime, products);

            order.Customer.Should().BeEquivalentTo(customer);
            order.DateTime.Should().BeSameDateAs(dateTime);
            order.Id.Should().Be(3);
            order.IsPayed.Should().BeFalse();
            order.PriceAlreadyPayed.Should().Be(0);
        }
        [TestMethod]
        public void Ctor_ShouldthrowException_IfProductListIsEmpty()
        {
            Dictionary<Product, int> products = new Dictionary<Product, int>();
            DateTime dateTime = new DateTime(2020, 08, 18, 12, 15, 56);
            Customer customer = new Customer("Jan Janssens", "Langemunt 49 9000 Gent");

            Action act = () =>
            {
                Order order = new Order(3, customer, dateTime, products);
            };

            act.Should().Throw<OrderException>().WithMessage("Order - invalid productsList");
        }
        #endregion
        #region Methods For Properties
        #region SetCustomer
        [TestMethod]
        public void SetCustomer_ShouldThrowException_IfCustomerIsNull()
        {
            DateTime dateTime = new DateTime(2020, 08, 18, 12, 15, 56);
            Order order = new Order(1, dateTime);

            Action act = () =>
            {
                order.SetCustomer(null);
            };

            act.Should().Throw<OrderException>().WithMessage("Order - SetCustomer - invalid customer");
        }
        [TestMethod]
        public void SetCustomer_ShouldThrowException_IfCustomerIsSameAsOldCustomer()
        {
            DateTime dateTime = new DateTime(2020, 08, 18, 12, 15, 56);
            Customer customer = new Customer("Jan Janssens", "Langemunt 49 9000 Gent");
            Order order = new Order(1, customer, dateTime);

            Action act = () =>
            {
                order.SetCustomer(customer);
            };

            act.Should().Throw<OrderException>().WithMessage("Order - SetCustomer - not new");
        }
        [TestMethod]
        public void SetCustomer_ShouldDeleteOrderFromOldCustomer_IfOldCustomerContainsOrder()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void SetCustomer_ShouldAddOrderToNewCustomer_IfCustomerDoesNotContainOrderYet()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void SetCustomer_ShouldChangeCustomer_IfCustomerIsValid()
        {
            Assert.Fail();
        }
        #endregion
        #region DeleteCustomer
        [TestMethod]
        public void DeleteCustomer_CustomerShouldBeNull()
        {
            Assert.Fail();
        }
        #endregion
        #region SetId
        [TestMethod]
        public void SetId_ShouldBeCorrect_IfIdIsValid()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void SetId_ShouldThrowException_IfIdIsNull()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void SetId_ShouldThrowException_IfIdIsZero()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void SetId_ShouldThrowException_IfIdIsNegative()
        {
            Assert.Fail();
        }
        #endregion
        #region SetDateTime
        [TestMethod]
        public void SetDateTime_ShouldHaveCorrectProperties_IfDateTimeIsValid()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void SetDateTime_ShouldThrowException_IfDateTimeIsNull()
        {
            Assert.Fail();
        }
        #endregion
        #region SetIsPayed
        [TestMethod]
        public void SetIsPayed_ShouldBeCorrect()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void SetIsPayed_ShouldUpdatePriceAlreadyPayed()
        {
            Assert.Fail();
        }
        #endregion
        #endregion Methods For Properties
        #region Methods
        #region GetProducts
        [TestMethod]
        public void GetProducts_ShouldGetAllProducts()
        {
            Assert.Fail();
        }
        #endregion
        #region AddProduct
        [TestMethod]
        public void AddProduct_ShouldThrowException_IfAmountIsZero()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void AddProduct_ShouldThrowException_IfAmountIsNegative()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void AddProduct_ShouldAddAmount_IfProductAlreadyExistsInList()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void AddProduct_ShouldAddProduct_IfProductDoesNotExistInList()
        {
            Assert.Fail();
        }
        #endregion
        #region DeleteProduct
        [TestMethod]
        public void DeleteProduct_ShouldThrowException_IfAmountIsZero()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void DeleteProduct_ShouldThrowException_IfAmountIsNegative()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void DeleteProduct_ShouldThrowException_IfAvailableAmountIsToSmall()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void DeleteProduct_ShouldRemoveProduct_IfAmountIsEqualToAvailableAmount()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void DeleteProduct_ShouldReduceAmount_IfAmountIsLessThanAvailableAmount()
        {
            Assert.Fail();
        }
        #endregion
        #region Price
        //TODO tests for calculate price
        #endregion
        #endregion
    }
}
