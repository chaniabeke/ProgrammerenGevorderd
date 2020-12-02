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
        #region SetName
        [TestMethod]
        public void SetName_ShouldBeCorrect_IfNameIsValid()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void SetName_ShouldThrowException_IfNameIsNull()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void SetName_ShouldThrowException_IfNameIsEmpty()
        {
            Assert.Fail();
        }
        #endregion
        #region SetAddress
        [TestMethod]
        public void SetAddress_ShouldBeCorrect_IfAddressIsValid()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void SetAddress_ShouldThrowException_IfAddressIsNull()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void SetAddress_ShouldThrowException_IfAddressIsEmpty()
        {
            Assert.Fail();
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
