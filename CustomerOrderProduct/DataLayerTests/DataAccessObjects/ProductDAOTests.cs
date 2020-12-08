using BusinessLayer.Models;
using DataLayer.DataAccessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayerTests.DataAccessObjects
{
    [TestClass]
    public class ProductDAOTests
    {

        [TestMethod]
        public void MethodName_condition_expectedValue()
        {
            ProductDAO productDAO = new ProductDAO();
            Product product = new Product("Coca-cola", 2);
            productDAO.AddProduct(product);
            productDAO.GetProduct(9);
            productDAO.RemoveProduct(product);

        }
    }
}
