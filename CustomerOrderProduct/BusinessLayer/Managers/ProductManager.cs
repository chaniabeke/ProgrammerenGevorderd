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
            _products.GetProduct(id);
            throw new NotImplementedException();
        }

        public IReadOnlyList<Product> GetAllProducts()
        {
            _products.GetAllProducts();
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            _products.AddProduct(product);
            throw new NotImplementedException();
        }

        public void RemoveProduct(Product product)
        {
            _products.RemoveProduct(product);
            throw new NotImplementedException();
        }

        #endregion Methodes
    }
}