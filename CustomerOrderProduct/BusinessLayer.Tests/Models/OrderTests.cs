using BusinessLayer.Exceptions;
using BusinessLayer.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Product product1 = new Product("Cola", 1.5m);
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
            Product product1 = new Product("Cola", 1.5m);
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

        #endregion Ctor

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
            //Arrange
            Dictionary<Product, int> products = new Dictionary<Product, int>();
            Product product1 = new Product("Cola", 1.5m);
            Product product2 = new Product("Fanta", 2);
            products.Add(product1, 5);
            products.Add(product2, 1);

            DateTime dateTime = new DateTime(2020, 08, 18, 12, 15, 56);
            Customer customer = new Customer("Jan Janssens", "Langemunt 49 9000 Gent");
            Order order = new Order(1, customer, dateTime, products);

            Customer newCustomer = new Customer("Bob Bobssons", "Korenmarkt 100 9000 Gent");

            //Act
            order.SetCustomer(newCustomer);

            //Arrange
            customer.GetOrders().Count.Should().Be(0);
            newCustomer.GetOrders().Count.Should().Be(1);
        }

        [TestMethod]
        public void SetCustomer_ShouldAddOrderToNewCustomer_IfCustomerDoesNotContainOrderYet()
        {
            //Arrange
            Dictionary<Product, int> products = new Dictionary<Product, int>();
            Product product1 = new Product("Cola", 1.5m);
            Product product2 = new Product("Fanta", 2);
            products.Add(product1, 5);
            products.Add(product2, 1);

            DateTime dateTime = new DateTime(2020, 08, 18, 12, 15, 56);
            Customer customer = new Customer("Jan Janssens", "Langemunt 49 9000 Gent");
            Order order = new Order(1, customer, dateTime, products);

            Customer newCustomer = new Customer("Bob Bobssons", "Korenmarkt 100 9000 Gent");

            //Act
            order.SetCustomer(newCustomer);

            //Arrange
            newCustomer.GetOrders().Count.Should().Be(1);
            newCustomer.GetOrders().First().Should().BeEquivalentTo(order);
        }

        [TestMethod]
        public void SetCustomer_ShouldChangeCustomer_IfCustomerIsValid()
        {
            //Arrange
            Dictionary<Product, int> products = new Dictionary<Product, int>();
            Product product1 = new Product("Cola", 1.5m);
            Product product2 = new Product("Fanta", 2);
            products.Add(product1, 5);
            products.Add(product2, 1);

            DateTime dateTime = new DateTime(2020, 08, 18, 12, 15, 56);
            Customer customer = new Customer("Jan Janssens", "Langemunt 49 9000 Gent");
            Order order = new Order(1, customer, dateTime, products);

            Customer newCustomer = new Customer("Bob Bobssons", "Korenmarkt 100 9000 Gent");

            //Act
            order.SetCustomer(newCustomer);

            //Arrange
            order.Customer.Should().BeEquivalentTo(newCustomer);
            order.Customer.Should().NotBeEquivalentTo(customer);
        }

        #endregion SetCustomer

        #region DeleteCustomer

        [TestMethod]
        public void DeleteCustomer_CustomerShouldBeNull()
        {
            DateTime dateTime = new DateTime(2020, 08, 18, 12, 15, 56);
            Customer customer = new Customer("Jan Janssens", "Langemunt 49 9000 Gent");
            Order order = new Order(1, customer, dateTime);

            order.DeleteCustomer();

            order.Customer.Should().BeNull();
        }

        #endregion DeleteCustomer

        #region SetId

        [TestMethod]
        public void SetId_ShouldBeCorrect_IfIdIsValid()
        {
            DateTime dateTime = new DateTime(2020, 08, 18, 12, 15, 56);
            Order order = new Order(1, dateTime);

            order.SetId(2);

            order.Id.Should().Be(2);
        }

       

        [TestMethod]
        public void SetId_ShouldThrowException_IfIdIsNegative()
        {
            DateTime dateTime = new DateTime(2020, 08, 18, 12, 15, 56);
            Order order = new Order(1, dateTime);

            Action act = () =>
            {
                order.SetId(-5);
            };

            act.Should().Throw<OrderException>().WithMessage("Order - invalid id");
        }

        #endregion SetId

        #region SetDateTime

        [TestMethod]
        public void SetDateTime_ShouldHaveCorrectProperties_IfDateTimeIsValid()
        {
            DateTime dateTime = new DateTime(2020, 08, 18, 12, 15, 56);
            Order order = new Order(1, dateTime);

            DateTime newDateTime = new DateTime(2021, 09, 20, 15, 00, 00);
            order.SetDateTime(newDateTime);

            order.DateTime.Should().Be(newDateTime);
        }

        #endregion SetDateTime

        #region SetIsPayed

        [TestMethod]
        public void SetIsPayed_ShouldBeCorrect()
        {
            Order order = new Order(5, DateTime.Now);

            order.IsPayed = true;

            order.IsPayed.Should().BeTrue();

            order.IsPayed = false;

            order.IsPayed.Should().BeFalse();
        }

        [TestMethod]
        public void SetIsPayed_ShouldUpdatePriceAlreadyPayed()
        {
            Order order = new Order(1, new DateTime(2020, 5, 5, 18, 00, 00));
            order.AddProduct(new Product("Whisky", 50), 2);
            order.AddProduct(new Product("Vodka", 12), 5);
            order.AddProduct(new Product("Leffe", 2.5m), 12);

            order.IsPayed = true;

            order.Price().Should().BeGreaterThan(0);
        }

        #endregion SetIsPayed

        #endregion Methods For Properties

        #region Methods

        #region GetProducts

        [TestMethod]
        public void GetProducts_ShouldGetAllProducts()
        {
            Order order = new Order(1, new DateTime(2020, 5, 5, 18, 00, 00));
            order.AddProduct(new Product("Whisky", 50), 2);
            order.AddProduct(new Product("Vodka", 12), 5);
            order.AddProduct(new Product("Leffe", 2.5m), 12);

            order.GetProducts().Count.Should().Be(3);
        }

        #endregion GetProducts

        #region AddProduct

        [TestMethod]
        public void AddProduct_ShouldThrowException_IfAmountIsZero()
        {
            Order order = new Order(1, new DateTime(2020, 5, 5, 18, 00, 00));

            Action act = () =>
            {
                order.AddProduct(new Product("Whisk"), 0);
            };

            act.Should().Throw<OrderException>().WithMessage("AddOrder - amount");
        }

        [TestMethod]
        public void AddProduct_ShouldThrowException_IfAmountIsNegative()
        {
            Order order = new Order(1, new DateTime(2020, 5, 5, 18, 00, 00));

            Action act = () =>
            {
                order.AddProduct(new Product("Whisk"), -2);
            };

            act.Should().Throw<OrderException>().WithMessage("AddOrder - amount");
        }

        [TestMethod]
        public void AddProduct_ShouldAddAmount_IfProductAlreadyExistsInList()
        {
            Order order = new Order(1, new DateTime(2020, 5, 5, 18, 00, 00));

            order.AddProduct(new Product("Whisky", 50), 5);
            order.AddProduct(new Product("Whisky", 50), 5);

            order.GetProducts().Count.Should().Be(1);
            order.GetProducts().First().Value.Should().Be(10);
        }

        [TestMethod]
        public void AddProduct_ShouldAddProduct_IfProductDoesNotExistInList()
        {
            Order order = new Order(1, new DateTime(2020, 5, 5, 18, 00, 00));
            Product product = new Product("Whisky", 50);
            order.AddProduct(product, 5);

            order.GetProducts().Count.Should().Be(1);
            Product testProduct = order.GetProducts().First().Key;
            testProduct.Should().BeEquivalentTo(product);
        }

        #endregion AddProduct

        #region DeleteProduct

        [TestMethod]
        public void DeleteProduct_ShouldThrowException_IfAmountIsZero()
        {
            Order order = new Order(1, new DateTime(2020, 5, 5, 18, 00, 00));
            Product product = new Product("Whisky", 50);
            order.AddProduct(product, 5);

            Action act = () =>
            {
                order.DeleteProduct(product, 0);
            };

            act.Should().Throw<OrderException>().WithMessage("DeleteProduct - amount");
        }

        [TestMethod]
        public void DeleteProduct_ShouldThrowException_IfAmountIsNegative()
        {
            Order order = new Order(1, new DateTime(2020, 5, 5, 18, 00, 00));
            Product product = new Product("Whisky", 50);
            order.AddProduct(product, 5);

            Action act = () =>
            {
                order.DeleteProduct(product, -8);
            };

            act.Should().Throw<OrderException>().WithMessage("DeleteProduct - amount");
        }

        [TestMethod]
        public void DeleteProduct_ShouldThrowException_IfAvailableAmountIsToSmall()
        {
            Order order = new Order(1, new DateTime(2020, 5, 5, 18, 00, 00));
            Product product = new Product("Whisky", 50);
            order.AddProduct(product, 5);

            Action act = () =>
            {
                order.DeleteProduct(product, 10);
            };

            act.Should().Throw<OrderException>().WithMessage("DeleteProduct - available amount is to small");
        }

        [TestMethod]
        public void DeleteProduct_ShouldRemoveProduct_IfAmountIsEqualToAvailableAmount()
        {
            Order order = new Order(1, new DateTime(2020, 5, 5, 18, 00, 00));
            Product product = new Product("Whisky", 50);
            order.AddProduct(product, 10);

            order.DeleteProduct(product, 10);

            order.GetProducts().Count.Should().Be(0);
        }

        [TestMethod]
        public void DeleteProduct_ShouldReduceAmount_IfAmountIsLessThanAvailableAmount()
        {
            Order order = new Order(1, new DateTime(2020, 5, 5, 18, 00, 00));
            Product product = new Product("Whisky", 50);
            order.AddProduct(product, 10);

            order.DeleteProduct(product, 5);

            order.GetProducts().Count.Should().Be(1);
            order.GetProducts().First().Value.Should().Be(5);
        }

        #endregion DeleteProduct

        #region Price

        [TestMethod]
        public void Price_ShouldReturn0_IfProductsIsEmpty()
        {
            Order order = new Order(1, new DateTime(2020, 5, 5, 18, 00, 00));

            order.IsPayed = true;

            order.Price().Should().Be(0);
        }

        [TestMethod]
        public void Price_ShouldReturnCorrectValue_IfProductsHasItems()
        {
            Customer customer = new Customer("Bob", "Dorpstraat 101");
            Order order1 = new Order(3, customer, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order2 = new Order(4, customer, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order3 = new Order(5, customer, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order4 = new Order(6, customer, new DateTime(2020, 5, 5, 18, 00, 00));
            Order order5 = new Order(7, customer, new DateTime(2020, 5, 5, 18, 00, 00));
            
            Order newOrder = new Order(1, customer, new DateTime(2020, 5, 5, 18, 00, 00));
            newOrder.AddProduct(new Product("Whisky", 50), 2);
            newOrder.AddProduct(new Product("Vodka", 12), 5);
            newOrder.AddProduct(new Product("Leffe", 2.5m), 12);

            newOrder.IsPayed = true;

            newOrder.Price().Should().Be(190);
        }

        [TestMethod]
        public void Price_ShouldReturnCorrectValueWithCustomerDiscount_IfCustomerHasDiscount()
        {
            Order order = new Order(1, new DateTime(2020, 5, 5, 18, 00, 00));
            order.AddProduct(new Product("Whisky", 50), 2);
            order.AddProduct(new Product("Vodka", 12), 5);
            order.AddProduct(new Product("Leffe", 2.5m), 12);

            order.IsPayed = true;

            order.Price().Should().Be(180.5m);
        }

        #endregion Price

        #endregion Methods
    }
}