using BusinessLayer.Exceptions;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Models
{
    public class Order
    {
        #region Fields
        private decimal _priceAlreadyPayed;
        private bool _isPayed;
        #endregion
        #region Properties

        public int Id { get; private set; }
        public bool IsPayed
        {
            get => _isPayed; set => _isPayed = SetPayed(value);
        }
        public decimal PriceAlreadyPayed
        {
            get => _priceAlreadyPayed; set => _priceAlreadyPayed = value;
        }
        public Customer Customer { get; private set; }
        public DateTime DateTime { get; private set; }
        private Dictionary<Product, int> _products = new Dictionary<Product, int>();
        public int ProductCount { get => _products.Keys.Count; }
        #endregion Properties

        #region Constructors

        public Order(DateTime dateTime)
        {
            SetDateTime(dateTime);
            IsPayed = false;
        }

        public Order(int id, DateTime dateTime) : this(dateTime) => SetId(id);

        public Order(DateTime dateTime, Customer customer) : this(dateTime) => SetCustomer(customer);


        public Order(int id, Customer customer, DateTime dateTime) : this(id, dateTime) => SetCustomer(customer);

        public Order(int id, Customer customer, DateTime dateTime, Dictionary<Product, int> products) : this(id, customer, dateTime)
        {
            if (products is null || products.Count == 0) throw new OrderException("Order - invalid productsList");
            _products = products;
        }

        public Order(int id, DateTime dateTime, bool isPayed, decimal priceAlreadyPayed, Customer customer): this(id, dateTime)
        {
            if(customer != null) SetCustomer(customer);
            IsPayed = isPayed;
            PriceAlreadyPayed = priceAlreadyPayed;
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
            if (id < 0) throw new OrderException("Order - invalid id");
            Id = id;
        }

        public void SetDateTime(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        private bool SetPayed(bool isPayed = true)
        {
            if (isPayed)
            {
                PriceAlreadyPayed = Price();
            }
            return isPayed;
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

        public decimal Price()
        {
            decimal price = 0; double discount = 0;
            if (Customer != null)
            {
                discount = Customer.Discount();
            }
            foreach (KeyValuePair<Product, int> kvp in _products)
            {
                price += kvp.Key.Price * kvp.Value * ((decimal)100.0 - (decimal)discount) / (decimal)100.0;
            }
            return price;
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   DateTime == order.DateTime;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        #endregion Methods
    }
}