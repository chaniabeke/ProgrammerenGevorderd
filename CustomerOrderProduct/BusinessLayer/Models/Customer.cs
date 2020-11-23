using CustomerOrderRESTService.BusinessLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class Customer
    {
        #region Fields
        private string _name;
        private string _address;
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            internal set
            {
                if (value == null) throw new ArgumentNullException();
                if (value == String.Empty) throw new BusinessException("name can't be empty");
                _name = value;
            }
        }
        public string Address
        {
            get { return _address; }
            internal set
            {
                if (value == null) throw new ArgumentNullException();
                if (value == String.Empty) throw new BusinessException("address can't be empty");
                _address = value;
            }
        }
        public double Discount { get; private set; } = 0;
        private List<Order> _orders = new List<Order>();
        #endregion

        #region Constructors
        public Customer(string name, string address)
        {
            if (name == String.Empty) throw new BusinessException("name can't be empty");
            Name = name ?? throw new ArgumentNullException(nameof(name));
            if (address == String.Empty) throw new BusinessException("name can't be empty");
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }
        #endregion

        #region Methods
        private void ChangeDiscount()
        {
            if (_orders.Count >= 5) Discount = 5;
            if (_orders.Count >= 10) Discount = 10;
        }
        internal void AddOrder(Order order)
        {
            _orders.Add(order);
            ChangeDiscount();
        }
        #endregion
    }
}
