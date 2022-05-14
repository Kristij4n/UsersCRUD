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
    public class UpdateUserViewModel : INotifyPropertyChanged
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
        public UpdateUserViewModel()
        {
            ObjUserService = new UserService();
            LoadData();
            CurrentUser = new UserDTO();
            searchCommand = new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
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

        #region UpdateOperation

        private RelayCommand updateCommand;

        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
        }

        public void Update()
        {
            try
            {
                var IsUpdated = ObjUserService.Update(CurrentUser);

                if (IsUpdated)
                {
                    Message = "User Updated";
                    LoadData();
                }
                else
                {
                    Message = "Update operation failed";
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
