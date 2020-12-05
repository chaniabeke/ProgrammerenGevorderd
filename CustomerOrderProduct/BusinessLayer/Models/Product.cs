﻿using BusinessLayer.Exceptions;

namespace BusinessLayer.Models
{
    public class Product
    {
        #region Properties

        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }

        #endregion Properties

        #region Constructors
        //TODO ASK not all products have a price
        public Product(string name) => SetName(name);

        public Product(string name, double price) : this(name) => SetPrice(price);

        public Product(int id, string name, double price) : this(name, price) => SetId(id);

        #endregion Constructors

        #region Methods For Properties

        public void SetPrice(double price)
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
    }
}