﻿using BusinessLayer.Exceptions;
using System.Collections.Generic;

namespace BusinessLayer.Models
{
    public class Customer
    {
        #region Properties

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        private List<Order> _orders = new List<Order>();

        #endregion Properties

        #region Constructors

        public Customer(string name, string address)
        {
            SetName(name);
            SetAddress(address);
        }

        public Customer(int id, string name, string address) : this(name, address) => SetId(id);

        public Customer(int id, string name, string address, List<Order> orders) : this(id, name, address)
        {
            if (orders == null || orders.Count == 0) throw new CustomerException("Customer - orders invalid");
            _orders = orders;
            foreach (Order order in orders) order.SetCustomer(this);
        }

        #endregion Constructors

        #region Methods For Properties

        public void SetId(int id)
        {
            if (id <= 0) throw new CustomerException("Customer Id invalid");
            Id = id;
        }

        public void SetName(string name)
        {
            if (name is null) throw new CustomerException("Customer name invalid");
            if (name.Trim().Length < 1) throw new CustomerException("Customer name invalid");
            Name = name;
        }

        public void SetAddress(string address)
        {
            if (address.Trim().Length < 1) throw new CustomerException("Customer address invalid");
            Address = address;
        }

        #endregion Methods For Properties

        #region Methods

        public int Discount()
        {
            if (_orders.Count < 5) return 0;
            if (_orders.Count < 10) return 5;
            return 10;
        }

        public IReadOnlyList<Order> GetOrders()
        {
            return _orders.AsReadOnly();
        }

        public bool HasOrder(Order order)
        {
            if (_orders.Contains(order)) return true;
            return false;
        }

        public void AddOrder(Order order)
        {
           // if (_orders.Contains(order)) throw new CustomerException("Customer : AddOrder - order already exists");
            _orders.Add(order);
            if (order.Customer != this) order.SetCustomer(this);
        }

        public void DeleteOrder(Order order)
        {
            if (!_orders.Contains(order)) throw new CustomerException("Customer : DeleteOrder - order does not exists");
            if (order.Customer == this)
                order.DeleteCustomer();
            _orders.Remove(order);
        }

        #endregion Methods
    }
}