using System.Windows;

namespace UsersCRUD
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
        }
    }
}
