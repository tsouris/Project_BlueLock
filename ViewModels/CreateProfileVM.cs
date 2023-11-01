using Project_BlueLock.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Project_BlueLock.ViewModels
{
    public class CreateProfileVM : BaseVM, IPageViewModel
    {
        private ICommand? _goToLoginPage;
        private ICommand? _goToPlayerProfilePage;
        public event EventHandler<EventArgs<string>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; } = "View 1";

        public CreateProfileVM(string pageIndex = "1")
        {
            PageId = pageIndex;
        }

        public ICommand GoToLoginPage
        {
            get
            {
                return _goToLoginPage ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "2");
                });
            }
        }

        public ICommand GoToPlayerProfilePage
        {
            get
            {
                return _goToPlayerProfilePage ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "3");
                });
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
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

        public List<string> Validate()
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(Name))
            {
                errors.Add("Name is required.");
            }

            if (string.IsNullOrWhiteSpace(Surname))
            {
                errors.Add("Surname is required.");
            }

            if (string.IsNullOrWhiteSpace(Username))
            {
                errors.Add("Username is required.");
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                errors.Add("Password is required.");
            }

            return errors;
        }
    }
}
