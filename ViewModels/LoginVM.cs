using Project_BlueLock.Utilities;
using System;
using System.Windows.Input;

namespace Project_BlueLock.ViewModels
{
    public class LoginVM : BaseVM, IPageViewModel
    {
        private ICommand _goToHomePage;
        private ICommand _goToCreateProfilePage;

        public event EventHandler<EventArgs<string>> ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; } = "Login";

        public LoginVM(string pageIndex = "2")
        {
            PageId = pageIndex;
        }

        public ICommand GoToHomePage
        {
            get
            {
                return _goToHomePage ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "4");
                });
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
    }
}
