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
        IReadOnlyList<Order> GetAllOrdersFromCustomer(int customerId);
        void RemoveOrder(int orderId);
        void UpdateOrder(int orderId, bool isPayed, decimal priceAlreadyPayed);
    }
}