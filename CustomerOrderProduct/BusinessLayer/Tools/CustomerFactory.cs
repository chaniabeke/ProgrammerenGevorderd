using BusinessLayer.Exceptions;
using BusinessLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Tools
{
    public static class CustomerFactory
    {
        public static Customer CreateCustomer(string naam, string adres)
        {
            try
            {
                return new Customer(naam.Trim(), adres.Trim());
            }
            catch (CustomerException ex)
            {
                throw new CustomerFactoryException("Create customer", ex);
            }
        }

        public static Customer CreateCustomer(int id, string naam, string adres)
        {
            try
            {
                return new Customer(id, naam.Trim(), adres.Trim());
            }
            catch (CustomerException ex)
            {
                throw new CustomerFactoryException("Create customer", ex);
            }
        }

        public static Customer CreateCustomer(int id, string naam, string adres, List<Order> bestellingen)
        {
            try
            {
                return new Customer(id, naam.Trim(), adres.Trim(), bestellingen);
            }
            catch (CustomerException ex)
            {
                throw new CustomerFactoryException("Create customer", ex);
            }
        }
    }
}