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
            return _orders.GetOrder(id);
        }

        public IReadOnlyList<Order> GetAllOrders()
        {
            return _orders.GetAllOrders();
        }

        public void AddOrder(Order order)
        {
            _orders.AddOrder(order);
        }

        public void RemoveOrder(int id)
        {
            _orders.RemoveOrder(id);
        }

        public IReadOnlyList<Order> GetOrders(Func<Order, bool> predicate)
        {
            throw new NotImplementedException();
        }

        #endregion Methodes
    }
}