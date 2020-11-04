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
    /// Interaction logic for TweedeVoorbeeldWindow.xaml
    /// </summary>
    public partial class TweedeVoorbeeldWindow : Window {
        public TweedeVoorbeeldWindow() {
            InitializeComponent();
        }

        private void Calander1_SelectedDatesChanged(object sender, SelectionChangedEventArgs e) {
            foreach(DateTime item in e.AddedItems) {
                GeselecteerdeDataListBox.Items.Add(item);
            }
        }
    }
}
