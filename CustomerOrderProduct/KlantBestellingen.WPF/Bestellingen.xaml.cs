using BusinessLayer.Models;
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
using System.Windows.Shapes;

namespace KlantBestellingen.WPF
{
    /// <summary>
    /// Interaction logic for Bestellingen.xaml
    /// </summary>
    public partial class Bestellingen : Window
    {
        private ObservableCollection<Order> _bestellingen = null;
        public Bestellingen()
        {
            InitializeComponent();
            _bestellingen = new ObservableCollection<Order>(Context.OrderManager.GetAllOrders());
            dgBestellingen.ItemsSource = _bestellingen;
            _bestellingen.CollectionChanged += _bestellingen_CollectionChanged;
        }

        /// <summary>
        /// Doorgeven aan business laag dat bestellingen werd toegevoegd of verwijderd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _bestellingen_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Order order in e.OldItems)
                {
                    Context.OrderManager.RemoveOrder(order.Id);
                }
            }
        }

        private void dgBestellingen_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var grid = (DataGrid)sender;
            if (Key.Delete == e.Key)
            {
                if (!(MessageBox.Show("Zeker dat je de bestelling wenst te verwijderen?", "Bevestig.", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
                {
                    // Cancel Delete.
                    e.Handled = true;
                    return;
                }

                // We moeten een while gebruiken en telkens testen want met foreach treden problemen op omdat de verzameling intussen telkens wijzigt!
                while (grid.SelectedItems.Count > 0)
                {
                    var row = grid.SelectedItems[0];
                    _bestellingen.Remove(row as Order);
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // We moeten een while gebruiken en telkens testen want met foreach treden problemen op omdat de verzameling intussen telkens wijzigt!
            while (dgBestellingen.SelectedItems.Count > 0)
            {
                var row = dgBestellingen.SelectedItems[0];
                _bestellingen.Remove(row as Order);
            }
        }
    }
}
