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
           return _products.GetProduct(id);
        }

        public IReadOnlyList<Product> GetAllProducts()
        {
            return _products.GetAllProducts();
        }

        public void AddProduct(Product product)
        {
            _products.AddProduct(product);
        }

        public void RemoveProduct(int id)
        {
             _products.RemoveProduct(id);
        }

        #endregion Methodes
    }
}