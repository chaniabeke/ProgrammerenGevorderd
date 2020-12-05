using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void MenuItem_Customers_Click(object sender, RoutedEventArgs e)
        {
            changingWindow.Source = new Uri("Pages/CustomersPage.xaml", UriKind.Relative);
        }

        private void MenuItem_Orders_Click(object sender, RoutedEventArgs e)
        {
            changingWindow.Source = new Uri("Pages/OrdersPage.xaml", UriKind.Relative);
        }

        private void MenuItem_Products_Click(object sender, RoutedEventArgs e)
        {
            changingWindow.Source = new Uri("Pages/ProductsPage.xaml", UriKind.Relative);
        }

        private void MenuItem_Close_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        #endregion
    }
}
