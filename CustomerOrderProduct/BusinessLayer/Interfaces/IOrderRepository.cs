using BusinessLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        Order GetOrder(int id);
        IReadOnlyList<Order> GetAllOrders();
        IReadOnlyList<Order> GetOrders(Func<Order, bool> predicate);
        void RemoveOrder(Order order);
    }
}