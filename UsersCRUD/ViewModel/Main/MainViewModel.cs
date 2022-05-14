using UsersCRUD.Core;
using UsersCRUD.ViewModel.About;
using UsersCRUD.ViewModel.User;

namespace UsersCRUD.ViewModel.Main
{
    class MainViewModel : ObervableObject
    {
        /// <summary>
        /// commands
        /// </summary>
        ///

        // about
        public RelayCommand AboutViewCommand { get; set; }

        // user

        public RelayCommand UserViewCommand { get; set; }
        public RelayCommand UserPreviewViewCommand { get; set; }
        public RelayCommand CreateUserViewCommand { get; set; }
        public RelayCommand UpdateUserViewCommand { get; set; }
        public RelayCommand DeleteUserViewCommand { get; set; }

        /// <summary>
        /// VM
        /// </summary>
        /// 

        // about

        public AboutViewModel AboutVM { get; set; }

        // user
        public UserViewModel UserVM { get; set; }
        public UserPreviewViewModel UserPreviewViewVM { get; set; }
        public CreateUserViewModel CreateUserVM { get; set; }
        public UpdateUserViewModel UpdateUserVM { get; set; }
        public DeleteUserViewModel DeleteUserVM { get; set; }

        /// <summary>
        /// current view
        /// </summary>
        /// 

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// relay command
        /// </summary>
        /// 

        public MainViewModel()
        {
            // about

            AboutVM = new AboutViewModel();

            // user
            UserVM = new UserViewModel();

            // user - preview view

            UserPreviewViewVM = new UserPreviewViewModel();

            // user - create user

            CreateUserVM = new CreateUserViewModel();

            // user - update user

            UpdateUserVM = new UpdateUserViewModel();

            // user - delete user

            DeleteUserVM = new DeleteUserViewModel();

            // set current
            CurrentView = AboutVM;

            // about

            AboutViewCommand = new RelayCommand(o =>
            {
                CurrentView = AboutVM;
            });

            // user
            UserViewCommand = new RelayCommand(o =>
            {
                CurrentView = UserVM;
            });

            // user - preview view
            UserPreviewViewCommand = new RelayCommand(o =>
            {
                CurrentView = UserPreviewViewVM;
            });

            // user - create user
            CreateUserViewCommand = new RelayCommand(o =>
            {
                CurrentView = CreateUserVM;
            });

            // user - update
            UpdateUserViewCommand = new RelayCommand(o =>
            {
                CurrentView = UpdateUserVM;
            });

            // user - delete
            DeleteUserViewCommand = new RelayCommand(o =>
            {
                CurrentView = DeleteUserVM;
            });

        }
    }
}