using BusinessLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        IReadOnlyList<Customer> GetAllCustomers();
        Customer GetCustomerWithOrders(int id);
        Customer GetCustomer(int id);
        void RemoveCustomer(int id);
    }
}