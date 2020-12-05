﻿using BusinessLayer.Exceptions;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Tools
{
    public static class ProductFactory
    {
        public static Product CreateProduct(string name, double price, int id)
        {
            try
            {
                return new Product(id, name.Trim(), price);
            }
            catch (ProductException ex)
            {
                throw new ProductFactoryException("Create product", ex);
            }
        }
    }
}