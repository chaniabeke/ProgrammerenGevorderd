using BusinessLayer.Exceptions;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Tools
{
    public static class OrderFactory
    {
        public static Order CreateOrder(int id)
        {
            try
            {
                return new Order(id, DateTime.Now);
            }
            catch (OrderException ex)
            {
                throw new OrderFactoryException("Create order", ex);
            }
        }

        public static Order CreateOrder(Customer customer, int id)
        {
            try
            {
                return new Order(id, customer, DateTime.Now);
            }
            catch (OrderException ex)
            {
                throw new OrderFactoryException("Create order", ex);
            }
        }

        public static Order CreateOrder(Customer customer, Dictionary<Product, int> products, int id)
        {
            try
            {
                return new Order(id, customer, DateTime.Now, products);
            }
            catch (OrderException ex)
            {
                throw new OrderFactoryException("Create order", ex);
            }
        }
    }
}