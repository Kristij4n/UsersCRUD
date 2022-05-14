using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UsersCRUD.Commands;
using UsersCRUD.Model;
using UsersCRUD.Service;

namespace UsersCRUD.ViewModel.User
{
    public class CreateUserViewModel : INotifyPropertyChanged
    {

        #region INotiyfPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        UserService ObjUserService;
        public CreateUserViewModel()
        {
            ObjUserService = new UserService();
            LoadData();
            CurrentUser = new UserDTO();
            saveCommand = new RelayCommand(Save);
        }

        #region Properties

        private UserDTO currentUser;

        public UserDTO CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; OnPropertyChanged("CurrentUser"); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        #endregion

        #region Display Operation
        private ObservableCollection<UserDTO> usersList;

        public ObservableCollection<UserDTO> UsersList
        {
            get { return usersList; }
            set { usersList = value; OnPropertyChanged("UsersList"); }
        }
        private void LoadData()
        {
            UsersList = new ObservableCollection<UserDTO>(ObjUserService.GetAll());
        }

        #endregion

        #region SaveOperation

        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        public void Save()
        {
            try
            {
                var IsSaved = ObjUserService.Add(CurrentUser);
                LoadData();
                if (IsSaved)
                    Message = "User saved";
                else
                    Message = "Save operation failed";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please refresh table, wrong OIB!");
            }
        }

        #endregion

    }
}
