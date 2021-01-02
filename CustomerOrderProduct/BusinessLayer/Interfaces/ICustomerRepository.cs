using BusinessLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        IReadOnlyList<Customer> GetAllCustomers();
        IReadOnlyList<Customer> GetCustomers(Func<Customer, bool> predicate);
        Customer GetCustomer(int id);
        void RemoveCustomer(Customer customer);
    }
}