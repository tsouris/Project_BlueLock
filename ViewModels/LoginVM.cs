using Project_BlueLock.Data.DB;
using Project_BlueLock.Utilities;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Project_BlueLock.ViewModels
{
    public class LoginVM : BaseVM, IPageViewModel
    {
        public ICommand LoginCommand { get; private set; }

        private ICommand _goToCreateProfilePage;
        
        private DatabaseManager databaseManager;

        public event EventHandler<EventArgs<string>> ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; } = "View 2";

        public LoginVM(string pageIndex = "2")
        {
            PageId = pageIndex;
            databaseManager = new DatabaseManager();
            LoginCommand = new RelayCommand(Login);
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        private void Login(object parameter)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Please enter both username and password.";
                return;
            }

            bool isValid = databaseManager.ValidateCredentials(Username, Password);

            if (isValid)
            {
                ViewChanged?.Raise(this, "4");
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
            }
        }

        public ICommand GoToCreateProfilePage
        {
            get
            {
                return _goToCreateProfilePage ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "1");
                });
            }
        }
    }
}
