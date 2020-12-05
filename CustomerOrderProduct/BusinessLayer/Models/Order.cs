using BusinessLayer.Exceptions;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Models
{
    public class Order
    {
        #region Properties

        public int Id { get; private set; }
        public bool IsPayed { get; private set; }
        public double PriceAlreadyPayed { get; private set; }
        public Customer Customer { get; private set; }
        public DateTime DateTime { get; private set; }
        private Dictionary<Product, int> _products = new Dictionary<Product, int>();

        #endregion Properties

        #region Constructors

        public Order(int id, DateTime dateTime)
        {
            SetId(id);
            SetDateTime(dateTime);
            IsPayed = false;
        }

        public Order(int id, Customer customer, DateTime dateTime) : this(id, dateTime) => SetCustomer(customer);

        public Order(int id, Customer customer, DateTime dateTime, Dictionary<Product, int> products) : this(id, customer, dateTime)
        {
            if (products is null || products.Count == 0) throw new OrderException("Order - invalid productsList");
            _products = products;
        }

        #endregion Constructors

        #region Methods For Properties

        public void SetCustomer(Customer newCustomer)
        {
            if (newCustomer == null) throw new OrderException("Order - SetCustomer - invalid customer");
            if (newCustomer == Customer) throw new OrderException("Order - SetCustomer - not new");

            //Check if old customer had order and deletes
            if (Customer != null)
            {
                if (Customer.HasOrder(this)) Customer.DeleteOrder(this);
            }

            //check if new customer has order and adds
            if (!newCustomer.HasOrder(this)) newCustomer.AddOrder(this);

            Customer = newCustomer;
        }

        public void DeleteCustomer()
        {
            Customer = null;
        }

        public void SetId(int id)
        {
            if (id <= 0) throw new OrderException("Order - invalid id");
            Id = id;
        }

        public void SetDateTime(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        public void SetPayed(bool isPayed = true)
        {
            IsPayed = isPayed;
            if (IsPayed)
            {
                PriceAlreadyPayed = Price();
            }
        }

        #endregion Methods For Properties

        #region Methods

        public IReadOnlyDictionary<Product, int> GetProducts()
        {
            return _products;
        }

        public void AddProduct(Product product, int amount)
        {
            if (amount <= 0) throw new OrderException("AddOrder - amount");
            if (_products.ContainsKey(product))
            {
                _products[product] += amount;
            }
            else
            {
                _products.Add(product, amount);
            }
        }

        public void DeleteProduct(Product product, int amount)
        {
            if (amount <= 0) throw new OrderException("DeleteProduct - amount");
            if (!_products.ContainsKey(product)) throw new OrderException("DeleteProduct - product not available");
            if (_products[product] < amount) throw new OrderException("DeleteProduct - available amount is to small");

            if (_products[product] == amount)
            {
                _products.Remove(product);
            }
            else
            {
                _products[product] -= amount;
            }
        }

        public double Price()
        {
            double price = 0.0; int korting = 0;
            if (Customer != null)
            {
                korting = Customer.Discount();
            }
            foreach (KeyValuePair<Product, int> kvp in _products)
            {
                price += kvp.Key.Price * kvp.Value * (100.0 - korting) / 100.0;
            }
            return price;
        }

        #endregion Methods
    }
}