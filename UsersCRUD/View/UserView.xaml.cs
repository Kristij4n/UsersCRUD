using System.Windows;
using System.Windows.Controls;

namespace UsersCRUD.View
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        public UserView()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow= new StartWindow();
            startWindow.Show();
            
            Window window = Window.GetWindow(this);
            if (window.Title == "MainWindow")
                window.Close();
        }
    }
}