﻿using System;
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

namespace UsersCRUD.View.User
{
    /// <summary>
    /// Interaction logic for UpdateUserView.xaml
    /// </summary>
    public partial class UpdateUserView : UserControl
    {
        public UpdateUserView()
        {
            InitializeComponent();
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
