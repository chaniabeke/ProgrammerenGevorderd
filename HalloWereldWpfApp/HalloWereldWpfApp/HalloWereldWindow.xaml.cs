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

namespace HalloWereldWpfApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HalloWereldWindow : Window {
        public HalloWereldWindow() {
            InitializeComponent();
        }

        private void GroetButton_Click(object sender, RoutedEventArgs e) {
            string begroeting = "Hallo";
            if (EngelsRadioButton.IsChecked == true) begroeting = "Hello"; 
            string boodschap = begroeting + " " + NaamTextBox.Text;
            if (HoofdlettersCheckBox.IsChecked == true) boodschap = boodschap.ToUpper(); 
            BoodschapLabel.Content = boodschap;
        }
    }
}
