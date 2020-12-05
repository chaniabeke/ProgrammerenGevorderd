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
            Customer customer = new Customer(5, "Han Hansens", "Dorpstraat 101 6000");

            customer.Should().BeOfType<Customer>();
        }
        [TestMethod]
        public void Ctor_ShouldHaveCorrectProperties_IfPropertiesAreValid()
        {
            Customer customer = new Customer(5, "Han Hansens", "Dorpstraat 101 6000");

            customer.Id.Should().Be(5);
            customer.Name.Should().Be("Han Hansens");
            customer.Address.Should().Be("Dorpstraat 101 6000");
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
            Order order1 = new Order(1, new DateTime(2020, 5, 5, 18, 00, 00));
            order1.AddProduct(new Product("Leffe"), 5);
            Order order2 = new Order(2, new DateTime(2020, 5, 5, 18, 00, 00));
            order2.AddProduct(new Product("Duvel"), 5);
            Order order3 = new Order(3, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order4 = new Order(4, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order5 = new Order(5, new DateTime(2020, 5, 5, 18, 00, 00));
            Customer customer = new Customer("Bob Ghent", "Kattenstraat 59 3000 Antwerpen");

            customer.AddOrder(order1);
            customer.Discount().Should().Be(0);

            customer.AddOrder(order2);
            customer.Discount().Should().Be(0);

            customer.AddOrder(order3);
            customer.Discount().Should().Be(0);

            customer.AddOrder(order4);
            customer.Discount().Should().Be(0);

            customer.AddOrder(order5);
            customer.Discount().Should().NotBe(0);
        }
        [TestMethod]
        public void Discount_ShouldBeFive_IfOrdersCountIsLessThenTen()
        {
            Order order1 = new Order(1, new DateTime(2020, 5, 5, 18, 00, 00));
            order1.AddProduct(new Product("Leffe"), 5);
            Order order2 = new Order(2, new DateTime(2020, 5, 5, 18, 00, 00));
            order2.AddProduct(new Product("Duvel"), 5);
            Order order3 = new Order(3, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order4 = new Order(4, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order5 = new Order(5, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order6 = new Order(6, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order7= new Order(7, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order8 = new Order(8, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order9 = new Order(9, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order10 = new Order(10, new DateTime(2020, 5, 5, 18, 00, 00));
            Customer customer = new Customer("Bob Ghent", "Kattenstraat 59 3000 Antwerpen");
            customer.AddOrder(order1);
            customer.AddOrder(order2);
            customer.AddOrder(order3);
            customer.AddOrder(order4);

            customer.AddOrder(order5);
            customer.Discount().Should().Be(5);

            customer.AddOrder(order6);
            customer.Discount().Should().Be(5);

            customer.AddOrder(order7);
            customer.Discount().Should().Be(5);

            customer.AddOrder(order8);
            customer.Discount().Should().Be(5);

            customer.AddOrder(order9);
            customer.Discount().Should().Be(5);

            customer.AddOrder(order10);
            customer.Discount().Should().NotBe(5);
        }
        [TestMethod]
        public void Discount_ShouldBeTen_IfOrdersCountIsMoreOrEqualToTen()
        {
            Order order1 = new Order(1, new DateTime(2020, 5, 5, 18, 00, 00));
            order1.AddProduct(new Product("Leffe"), 5);
            Order order2 = new Order(2, new DateTime(2020, 5, 5, 18, 00, 00));
            order2.AddProduct(new Product("Duvel"), 5);
            Order order3 = new Order(3, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order4 = new Order(4, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order5 = new Order(5, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order6 = new Order(6, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order7 = new Order(7, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order8 = new Order(8, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order9 = new Order(9, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order10 = new Order(10, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order11 = new Order(11, new DateTime(2020, 5, 5, 18, 00, 00));
            Customer customer = new Customer("Bob Ghent", "Kattenstraat 59 3000 Antwerpen");
            customer.AddOrder(order1);
            customer.AddOrder(order2);
            customer.AddOrder(order3);
            customer.AddOrder(order4);
            customer.AddOrder(order5);
            customer.AddOrder(order6);
            customer.AddOrder(order7);
            customer.AddOrder(order8);
            customer.AddOrder(order9);
            
            customer.AddOrder(order10);
            customer.Discount().Should().Be(10);

            customer.AddOrder(order11);
            customer.Discount().Should().Be(10);
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
