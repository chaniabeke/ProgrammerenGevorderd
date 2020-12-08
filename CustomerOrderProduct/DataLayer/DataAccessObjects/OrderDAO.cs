using BusinessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataLayer.DataAccessObjects
{
    public class OrderDAO
    {
        #region Fields

        private readonly string connectionString;

        #endregion Fields

        #region Constructors

        public OrderDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #endregion Constructors

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