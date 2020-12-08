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
            throw new NotImplementedException();
        }

        public IReadOnlyList<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        public void AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void RemoveOrder(Order order)
        {
            throw new NotImplementedException();
        }

        #endregion Methodes
    }
}