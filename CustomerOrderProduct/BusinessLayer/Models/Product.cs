using CustomerOrderRESTService.BusinessLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class Product
    {
        #region Fields
        private string _name;
        private decimal _price;
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null) throw new ArgumentNullException();
                if (value == String.Empty) throw new BusinessException("name can't be empty");
                _name = value;
            }
        }
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value <= 0) throw new BusinessException("price can't be less or equal to 0");
                _price = value;
            }
        }
        #endregion

        #region Constructors
        public Product(string name, decimal price)
        {
            if (name == String.Empty) throw new BusinessException("name can't be empty");
            Name = name ?? throw new ArgumentNullException(nameof(name));
            if (price <= 0) throw new BusinessException("price can't be less or equal to 0");
            Price = price;
        }
        #endregion
    }
}
