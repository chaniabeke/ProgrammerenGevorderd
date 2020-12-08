using BusinessLayer.Managers;
using CommonLayer;

namespace ConsoleApp.Models
{
    public static class Managers
    {
        public static CustomerManager CustomerManager { get; } = ManagerFactory.CreateCustomerManager();
        public static ProductManager ProductManager { get; } = ManagerFactory.CreateProductManager();
        public static OrderManager OrderManager { get; } = ManagerFactory.CreateOrderManager();
    }
}