﻿using BusinessLayer.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KlantBestellingen.WPF
{
    /// <summary>
    /// Interaction logic for Klanten.xaml
    /// </summary>
    public partial class Klanten : Window
    {
        // Interface INotifyPropertyChanged
        private ObservableCollection<Customer> _klanten = null;

        public Klanten()
        {
            InitializeComponent();
            _klanten = new ObservableCollection<Customer>(Context.CustomerManager.GetAllCustomers());
            dgKlanten.ItemsSource = _klanten;
            _klanten.CollectionChanged += _klanten_CollectionChanged;
        }

        /// <summary>
        /// Doorgeven aan business laag dat klant werd toegevoegd of verwijderd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _klanten_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Customer klant in e.OldItems)
                {
                    Context.CustomerManager.RemoveCustomer(klant.Id);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Customer klant in e.NewItems)
                {
                    Context.CustomerManager.AddCustomer(klant);
                }
            }
        }

        private void BtnNieuweKlant_Click(object sender, RoutedEventArgs e)
        {
            // Preconditie
            if (string.IsNullOrEmpty(TbKlantNaam?.Text) || string.IsNullOrEmpty(TbKlantAdres?.Text))
            {
                MessageBox.Show("Geef alle klantgegevens op!");
                return;
            }

            var klant = new Customer(TbKlantNaam.Text, TbKlantAdres.Text);
            // Omdat we een ObservableCollection<Klant> gebruiken, wordt onze wijziging meteen doorgegeven naar de gui (.Items wijzigen zou threading problemen geven):
            // Omdat we ObservableCollection<Klant> gebruiken en er een event gekoppeld is aan delete/add hiervan, wordt ook de business layer aangepast!
            _klanten.Add(klant);
        }

        private void Tb_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(TbKlantNaam.Text) && !string.IsNullOrEmpty(TbKlantAdres.Text))
            {
                BtnNieuweKlant.IsEnabled = true;
            }
            else
            {
                BtnNieuweKlant.IsEnabled = false;
            }
        }

        private void dgKlanten_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var grid = (DataGrid)sender;
            if (Key.Delete == e.Key)
            {
                if (!(MessageBox.Show("Zeker dat je de klant wenst te verwijderen?", "Bevestig.", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
                {
                    // Cancel Delete.
                    e.Handled = true;
                    return;
                }

                // We moeten een while gebruiken en telkens testen want met foreach treden problemen op omdat de verzameling intussen telkens wijzigt!
                while (grid.SelectedItems.Count > 0)
                {
                    var row = grid.SelectedItems[0];
                    _klanten.Remove(row as Customer);
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // We moeten een while gebruiken en telkens testen want met foreach treden problemen op omdat de verzameling intussen telkens wijzigt!
            while (dgKlanten.SelectedItems.Count > 0)
            {
                var row = dgKlanten.SelectedItems[0];
                _klanten.Remove(row as Customer);
            }
        }
    }
}
