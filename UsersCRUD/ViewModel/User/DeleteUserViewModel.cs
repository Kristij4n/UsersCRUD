using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersCRUD.Commands;
using UsersCRUD.Model;
using UsersCRUD.Service;

namespace UsersCRUD.ViewModel.User
{
    public class DeleteUserViewModel : INotifyPropertyChanged
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
        public DeleteUserViewModel()
        {
            ObjUserService = new UserService();
            LoadData();
            CurrentUser = new UserDTO();
            searchCommand = new RelayCommand(Search);
            deleteCommand = new RelayCommand(Delete);
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

        #region SearchOperation

        private RelayCommand searchCommand;

        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
        }

        public void Search()
        {
            try
            {
                var ObjJob = ObjUserService.Search(CurrentUser.Id);

                if (ObjJob != null)
                {
                    CurrentUser.Oib = ObjJob.Oib;
                    CurrentUser.Name = ObjJob.Name;
                    CurrentUser.Surname = ObjJob.Surname;
                    CurrentUser.City = ObjJob.City;
                    CurrentUser.Address = ObjJob.Address;
                    CurrentUser.Phone = ObjJob.Phone;
                    CurrentUser.Mail = ObjJob.Mail;

                }
                else
                {
                    Message = "User not found";
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region DeleteOperation

        private RelayCommand deleteCommand;

        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
        }

        public void Delete()
        {
            try
            {
                var IsDelete = ObjUserService.Delete(CurrentUser.Id);

                if (IsDelete)
                {
                    Message = "User deleted";
                    LoadData();
                }
                else
                {
                    Message = "Delete operation failed";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        #endregion

    }
}
