using BusinessLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        Order GetOrder(int id);
        IReadOnlyList<Order> GetOrders();
        void RemoveOrder(Order order);
    }
}