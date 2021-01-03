using BusinessLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        IReadOnlyList<Product> GetAllProducts();
        Product GetProduct(int id);
        void RemoveProduct(int id);
    }
}