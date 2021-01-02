using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer.Tools;
using System;
using System.Collections.Generic;

namespace DataLayer.DataAccessObjects
{
    public class OrderDAO : IOrderRepository
    {
        #region Fields

        private readonly string connectionString;

        #endregion Fields

        #region Constructors

        public OrderDAO()
        {
            this.connectionString = Util.GetConnectionString();
        }

        #endregion Constructors

        #region Methodes

        public Order GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Order> GetAllOrders()
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

        public IReadOnlyList<Order> GetOrders(Func<Order, bool> predicate)
        {
            throw new NotImplementedException();
        }

        #endregion Methodes
    }
}