using CustomerOrderRESTService.BusinessLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class Order
    {
        #region Fields
        private int _id;
        #endregion

        #region Properties
        public int Id
        {
            get { return _id; }
            set
            {
                if (value < -1) throw new BusinessException("id can't be lower than 0");
                _id = value;
            }
        }
        private Dictionary<Product, int> _products = new Dictionary<Product, int>();
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        private decimal? _totalPrice { get; set; }
        private bool _isPayed = false;
        #endregion

        #region Constructors
        public Order(DateTime orderDate)
        {
            OrderDate = orderDate;
        }
        public Order(DateTime orderDate, Customer customer)
        {
            OrderDate = orderDate;
            Customer = customer;
        }
        #endregion

        #region Methods
        public void AddProduct(Product product, int amount)
        {
            if (amount <= 0) throw new BusinessException("amount can't be less or equal to 0");
            if (_products.ContainsKey(product)) throw new BusinessException("order already contains product");
            if (_isPayed == true) throw new BusinessException("order has already been paid");
            _products.Add(product, amount);
        }
        public Dictionary<Product, int> GetProducts()
        {
            return _products;
        }
        //public void RemoveProduct(Product product, int amount)
        //{
        //    if (!_products.ContainsKey(product)) throw new BusinessException("product doesn't exist");
        //    _products.Remove(product);
        //}
        public Decimal? GetTotalPrice()
        {
            if (_isPayed == true) return _totalPrice;
            return null;
        }
        public void SetTotalPrice(double discount)
        {
            decimal totalPrice = 0;
            foreach (var product in _products)
            {
                totalPrice += product.Key.Price * product.Value;
            }
            _totalPrice = (totalPrice / 100) * (decimal)discount;
        }
        public void Pay()
        {
            _isPayed = true;
            if (Customer != null) Customer.AddOrder(this);
        }
        #endregion
    }
}
