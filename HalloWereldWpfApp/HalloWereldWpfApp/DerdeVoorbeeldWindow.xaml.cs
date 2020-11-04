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
using System.Windows.Shapes;

namespace HalloWereldWpfApp {
    /// <summary>
    /// Interaction logic for DerdeVoorbeeldWindow.xaml
    /// </summary>
    public partial class DerdeVoorbeeldWindow : Window {
        public DerdeVoorbeeldWindow() {
            InitializeComponent();
        }
        private bool _inhoudTextBoxChanged; 
        private void InhoudTextBox_TextChanged(object sender, TextChangedEventArgs e) { 
            _inhoudTextBoxChanged = true; }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (_inhoudTextBoxChanged) {
                MessageBoxResult antwoord = MessageBox.Show("Er zijn wijzigingen aangebracht, wil u deze bewaren?", Title, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (antwoord == MessageBoxResult.Yes) {
                    Opslaan(); 
                } else if (antwoord == MessageBoxResult.No) {
                    //Niets doen. 
                } else {
                    //if (antwoord == MessageBoxResult.Cancel) 
                    //Event annuleren: 
                    e.Cancel = true;
                }
            }
        }
        private void OpslaanMenuItem_Click(object sender, RoutedEventArgs e) { Opslaan(); }
        private void Opslaan() {
            //Opslaan... 
            _inhoudTextBoxChanged = false;
            MessageBox.Show("De wijzigingen zijn bewaard.", Title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void AfsluitenMenuItem_Click(object sender, RoutedEventArgs e) { //Sluit het venster: 
            Close();
        }
    }
}

