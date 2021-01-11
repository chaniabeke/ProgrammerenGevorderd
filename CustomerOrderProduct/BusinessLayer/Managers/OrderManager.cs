using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Managers
{
    public class OrderManager : IOrderRepository
    {
        #region Fields
        private readonly IOrderRepository _orders;
        #endregion

        #region Constructors
        public OrderManager(IOrderRepository orders) => _orders = orders;
        #endregion

        #region Methodes

        public Order GetOrder(int id)
        {
            if (id <= 0) throw new OrderManagerException("OrderManager - invalid id");
            return _orders.GetOrder(id);
        }

        public IReadOnlyList<Order> GetAllOrders()
        {
            return _orders.GetAllOrders();
        }

        public void AddOrder(Order order)
        {
            if (order == null) throw new OrderManagerException("OrderManager - order is null");
            _orders.AddOrder(order);
        }

        public void RemoveOrder(int id)
        {
            if (id <= 0) throw new OrderManagerException("OrderManager - invalid id");
            if (GetOrder(id) == null) throw new CustomerManagerException("OrderManager - order doesn't exist");
            if (!GetOrder(id).IsPayed) throw new CustomerManagerException("OrderManager - order needs to be payed first");
            _orders.RemoveOrder(id);
        }

        public IReadOnlyList<Order> GetAllOrdersFromCustomer(int customerId)
        {
            if (customerId <= 0) throw new OrderManagerException("OrderManager - invalid id");
            return _orders.GetAllOrdersFromCustomer(customerId);
        }

        public void UpdateOrder(int orderId, bool isPayed, decimal priceAlreadyPayed)
        {
            _orders.UpdateOrder(orderId, isPayed, priceAlreadyPayed);
        }
        #endregion Methodes
    }
}