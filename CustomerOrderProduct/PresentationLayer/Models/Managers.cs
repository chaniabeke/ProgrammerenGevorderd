using BusinessLayer.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models
{
    public static class Managers
    {
        public static CustomerManager CustomerManager { get; } = new CustomerManager();
        public static ProductManager ProductManager { get; } = new ProductManager();
        public static OrderManager OrderManager { get; } = new OrderManager();
    }
}
