using BusinessLayer.Managers;
using DataLayer.DataAccessObjects;

namespace CommonLayer
{
    public static class ManagerFactory
    {
        public static CustomerManager CreateCustomerManager()
        {
            return new CustomerManager(customers: new CustomerDAO());
        }
        public static OrderManager CreateOrderManager()
        {
            return new OrderManager(orders: new OrderDAO());
        }
        public static ProductManager CreateProductManager()
        {
            return new ProductManager(products: new ProductDAO());
        }
    }
}
