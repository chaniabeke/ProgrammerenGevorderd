using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Managers
{
    public class ProductManager : IProductRepository
    {
        #region Fields
        private readonly IProductRepository _products;
        #endregion

        #region Constructors
        public ProductManager(IProductRepository products) => _products = products; 
        #endregion

        #region Methodes

        public Product GetProduct(int id)
        {
           if (id <= 0) throw new OrderManagerException("OrderManager - invalid id");
            return _products.GetProduct(id);
        }

        public IReadOnlyList<Product> GetAllProducts()
        {
            return _products.GetAllProducts();
        }

        public void AddProduct(Product product)
        {
            //TODO MANAGER => exception if product with name exist
            if (product == null) throw new ProductManagerException("ProductManager - product is null");
            _products.AddProduct(product);
        }

        public void RemoveProduct(int id)
        {
            if (id <= 0) throw new OrderManagerException("OrderManager - invalid id");
            if (GetProduct(id) == null) throw new CustomerManagerException("OrderManager - order doesn't exist");
            //TODO MANAGER if product still exists in orders => exception
            _products.RemoveProduct(id);
        }

        #endregion Methodes
    }
}