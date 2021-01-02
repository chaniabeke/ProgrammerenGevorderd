using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Managers
{
    public class CustomerManager : ICustomerRepository
    {
        #region Fields
        private readonly ICustomerRepository _customers;
        #endregion

        #region Constructors
        public CustomerManager(ICustomerRepository customers) => _customers = customers; 
        #endregion

        #region Methodes

        public Customer GetCustomer(int id)
        {
            _customers.GetCustomer(id);
            throw new NotImplementedException();
        }

        public IReadOnlyList<Customer> GetCustomers(Func<Customer, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Customer> GetAllCustomers()
        {
            _customers.GetAllCustomers();
            throw new NotImplementedException();
        }

    


        public void AddCustomer(Customer customer)
        {
            _customers.AddCustomer(customer);
            throw new NotImplementedException();
        }

        public void RemoveCustomer(Customer customer)
        {
            _customers.RemoveCustomer(customer);
            throw new NotImplementedException();
        }
        #endregion Methodes
    }
}