using BusinessLayer.Managers;
using CommonLayer;
using System;

namespace KlantBestellingen.WPF
{
    public static class Context
    {
        #region Properties
        public static CustomerManager CustomerManager { get; } = ManagerFactory.CreateCustomerManager();
        public static ProductManager ProductManager { get; } = ManagerFactory.CreateProductManager();
        public static OrderManager OrderManager { get; } = ManagerFactory.CreateOrderManager();
        #endregion
    }
}