using System.Windows;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: "
            + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            // We zeggen hier dat de exception door ons afgehandeld is
            e.Handled = true;
        }
    }
}