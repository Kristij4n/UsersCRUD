using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using UsersCRUD.Model;
using UsersCRUD.Service;

namespace UsersCRUD.ViewModel.User
{
    public class UserPreviewViewModel : INotifyPropertyChanged
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
        public UserPreviewViewModel()
        {
            ObjUserService = new UserService();
            LoadData();
            CurrentUser = new UserDTO();
        }

        #region Properties

        private UserDTO currentUser;

        public UserDTO CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; OnPropertyChanged("CurrentUser"); }
        }

        private string _TextSearch;
        public string TextSearch
        {
            get { return _TextSearch; }
            set
            {
                _TextSearch = value;
                OnPropertyChanged("TextSearch");
                View.Refresh();
            }
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
            this._view = new ListCollectionView(this.usersList);
            this._view.Filter = Filter;

        }

        private ListCollectionView _view;
        public ICollectionView View
        {
            get { return this._view; }
        }
        private bool Filter(object item)
        {
            if (String.IsNullOrEmpty(TextSearch))
                return true;

            else
                return ((item as UserDTO).Oib.ToString().IndexOf(TextSearch, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    ((item as UserDTO).Name.IndexOf(TextSearch, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    ((item as UserDTO).Surname.IndexOf(TextSearch, StringComparison.OrdinalIgnoreCase) >= 0);                   
        }

        #endregion

    }
}
