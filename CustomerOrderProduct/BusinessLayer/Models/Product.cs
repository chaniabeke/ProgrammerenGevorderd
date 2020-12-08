using BusinessLayer.Exceptions;
using System;

namespace BusinessLayer.Models
{
    public class Product
    {
        #region Properties

        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        #endregion Properties

        #region Constructors

        //TODO ASK not all products have a price
        public Product(string name) => SetName(name);

        public Product(string name, decimal price) : this(name) => SetPrice(price);

        public Product(int id, string name, decimal price) : this(name, price) => SetId(id);

        #endregion Constructors

        #region Methods For Properties

        public void SetPrice(decimal price)
        {
            if (price <= 0) throw new ProductException("Product price invalid");
            Price = price;
        }

        public void SetName(string name)
        {
            if (name.Trim().Length < 1) throw new ProductException("Product name invalid");
            Name = name;
        }

        public void SetId(int id)
        {
            if (id <= 0) throw new ProductException("Product Id invalid");
            Id = id;
        }

        #endregion Methods For Properties

        #region Methods

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Name == product.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

        #endregion Methods
    }
}