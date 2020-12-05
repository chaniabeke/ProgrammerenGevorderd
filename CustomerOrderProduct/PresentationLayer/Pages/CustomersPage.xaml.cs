using BusinessLayer.Models;
using BusinessLayer.Tools;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLayer.Pages
{
    /// <summary>
    /// Interaction logic for CustomersPage.xaml
    /// </summary>
    public partial class CustomersPage : Page
    {
        #region Properties
        private ObservableCollection<Customer> _customers = null;
        #endregion
        #region Constructor
        public CustomersPage()
        {
            InitializeComponent();
            _customers = new ObservableCollection<Customer>(Managers.CustomerManager.GetAllCustomers());
            dgCustomers.ItemsSource = _customers;
            _customers.CollectionChanged += _customers_CollectionChanged;
        }
        #endregion

        #region Methods
        private void _customers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Customer customer in e.OldItems)
                {
                    Managers.CustomerManager.RemoveCustomer(customer);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Customer customer in e.NewItems)
                {
                    Managers.CustomerManager.AddCustomer(customer);
                }
            }
        }
        #endregion
        #region EventMethodsUI
        private void dgCustomers_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (!(MessageBox.Show("Are you sure you want to delete this customer?", "Confirm.", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
            {
                e.Handled = true;
            }
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName?.Text) || string.IsNullOrEmpty(tbAddress?.Text))
            {
                MessageBox.Show("Provide all customer information!");
                return;
            }

            Customer customer = CustomerFactory.CreateCustomer(tbName.Text, tbAddress.Text);
            _customers.Add(customer);
        }

        private void tb_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(tbAddress.Text))
            {
                btnAddCustomer.IsEnabled = true;
            }
            else
            {
                btnAddCustomer.IsEnabled = false;
            }
        }
        #endregion
    }
}
