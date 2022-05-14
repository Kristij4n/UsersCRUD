using System.Windows;
using System.Windows.Controls;

namespace UsersCRUD.View.User
{
    /// <summary>
    /// Interaction logic for UserPreviewView.xaml
    /// </summary>
    public partial class UserPreviewView : UserControl
    {
        public UserPreviewView()
        {
            InitializeComponent();
            //DataContext = new UserPreviewViewModel();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            userWindow.Show();

            Window window = Window.GetWindow(this);
            if (window.Title == "UserWindow")
                window.Close();
        }
    }
}
