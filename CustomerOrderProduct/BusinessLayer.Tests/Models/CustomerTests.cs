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
    public class CustomerTests
    {
        #region Ctor
        [TestMethod]
        public void Ctor_ShouldBeOfTypeCustomer_IfPropertiesAreValid()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void Ctor_ShouldHaveCorrectProperties_IfPropertiesAreValid()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void Ctor_ShouldThrowException_IfOrdersListIsNull()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void Ctor_ShouldThrowException_IfOrdersListIsEmpty()
        {
            Assert.Fail();
        }
        #endregion
        #region Methods For Properties
        #region SetId
        [TestMethod]
        public void SetId_ShouldBeCorrect_IfIdIsValid()
        {
            Customer customer = new Customer("Kim De Grootte", "Vrijdagsmarkt 45 9000 Gent");

            customer.SetId(5);

            customer.Id.Should().Be(5);
        }
        [TestMethod]
        public void SetId_ShouldThrowException_IfIdIsZero()
        {
            Customer customer = new Customer("Kim De Grootte", "Vrijdagsmarkt 45 9000 Gent");

            Action act = () =>
            {
                customer.SetId(0);
            };

            act.Should().Throw<CustomerException>().WithMessage("Customer id invalid");
        }
        [TestMethod]
        public void SetId_ShouldThrowException_IfIdIsNegative()
        {
            Customer customer = new Customer("Kim De Grootte", "Vrijdagsmarkt 45 9000 Gent");

            Action act = () =>
            {
                customer.SetId(-8);
            };

            act.Should().Throw<CustomerException>().WithMessage("Customer id invalid");
        }
        #endregion
        #region SetName
        [TestMethod]
        public void SetName_ShouldBeCorrect_IfNameIsValid()
        {
            Customer customer = new Customer("Kim De Grootte", "Vrijdagsmarkt 45 9000 Gent");

            customer.SetName("Leo De Grootte");

            customer.Name.Should().Be("Leo De Grootte");
        }
        [TestMethod]
        public void SetName_ShouldThrowException_IfNameIsNull()
        {
            Customer customer = new Customer("Kim De Grootte", "Vrijdagsmarkt 45 9000 Gent");

            Action act = () =>
            {
                customer.SetName(null);
            };

            act.Should().Throw<CustomerException>().WithMessage("Customer name invalid");
        }
        [TestMethod]
        public void SetName_ShouldThrowException_IfNameIsEmpty()
        {
            Customer customer = new Customer("Kim De Grootte", "Vrijdagsmarkt 45 9000 Gent");

            Action act = () =>
            {
                customer.SetName("        ");
            };

            act.Should().Throw<CustomerException>().WithMessage("Customer name invalid");
        }
        #endregion
        #region SetAddress
        [TestMethod]
        public void SetAddress_ShouldBeCorrect_IfAddressIsValid()
        {
            Customer customer = new Customer("Kim De Grootte", "Vrijdagsmarkt 45 9000 Gent");

            customer.SetAddress("Vrijdagsmarkt 45B 9000 Gent");

            customer.Address.Should().Be("Vrijdagsmarkt 45B 9000 Gent");
        }
        [TestMethod]
        public void SetAddress_ShouldThrowException_IfAddressIsEmpty()
        {
            Customer customer = new Customer("Kim De Grootte", "Vrijdagsmarkt 45 9000 Gent");

            Action act = () =>
            {
                customer.SetAddress("        ");
            };

            act.Should().Throw<CustomerException>().WithMessage("Customer address invalid");
        }
        #endregion
        #endregion
        #region Methods
        #region Discount
        [TestMethod]
        public void Discount_ShouldBeZero_IfOrdersCountIsLessThenFive()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void Discount_ShouldBeFive_IfOrdersCountIsLessThenTen()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void Discount_ShouldBeTen_IfOrdersCountIsMoreThenTen()
        {
            Assert.Fail();
        }
        #endregion
        #region GetOrders
        [TestMethod]
        public void GetOrders_ShouldGetAllOrders()
        {
            Assert.Fail();
        }
        #endregion
        #region HasOrder
        [TestMethod]
        public void HasOrder_ShouldReturnTrue_IfOrderExistInOrdersList()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void HasOrder_ShouldReturnFalse_IfOrderDoesNotExistInOrdersList()
        {
            Assert.Fail();
        }
        #endregion
        #region AddOrder
        [TestMethod]
        public void AddOrder_ShouldThrowException_IfOrderAlreadyExist()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void AddOrder_ShouldAddOrderCorrect_IfOrderDoesNotExist()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void AddOrder_ShouldChangeCustomer_IfOrderHasOtherCustomer()
        {
            Assert.Fail();
        }
        #endregion
        #region DeleteOrder
        [TestMethod]
        public void DeleteOrder_ShouldThrowException_IfOrderDoesNotExist()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void DeleteOrder_ShouldDeleteCustomerFromOrder_IfOrderHasCustomer()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void DeleteOrder_ShouldDeleteOrder_IfOrderExist()
        {
            Assert.Fail();
        }
        #endregion
        #endregion
    }
}
