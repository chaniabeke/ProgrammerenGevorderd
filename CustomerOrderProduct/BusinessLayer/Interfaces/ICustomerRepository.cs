using BusinessLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        IReadOnlyList<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
        void RemoveCustomer(Customer customer);
    }
}