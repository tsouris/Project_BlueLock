using Project_BlueLock.Data.DB;
using Project_BlueLock.Utilities;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Project_BlueLock.ViewModels
{
    public class CreateProfileVM : BaseVM, IPageViewModel
    {
        public ICommand NextCommand { get; private set; }

        private ICommand? _goToLoginPage;

        public event EventHandler<EventArgs<string>>? ViewChanged;

        public string PageId { get; set; }

        public string Title { get; set; } = "View 1";

        public CreateProfileVM(string pageIndex = "1")
        {
            PageId = pageIndex;
            NextCommand = new RelayCommand(CreateProfile);
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
                TbNameErrorVisibility = Visibility.Collapsed;
                TbNameErrorText = "";
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
                TbSurnameErrorVisibility = Visibility.Collapsed;
                TbSurnameErrorText = "";
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
                TbUsernameErrorVisibility = Visibility.Collapsed;
                TbUsernameErrorText = "";
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
                TbPasswordErrorVisibility = Visibility.Collapsed;
                TbPasswordErrorText = "";
            }
        }

        private Visibility tbNameErrorVisibility = Visibility.Collapsed;
        public Visibility TbNameErrorVisibility
        {
            get { return tbNameErrorVisibility; }
            set
            {
                tbNameErrorVisibility = value;
                OnPropertyChanged(nameof(TbNameErrorVisibility));
            }
        }

        private string tbNameErrorText;
        public string TbNameErrorText
        {
            get { return tbNameErrorText; }
            set
            {
                tbNameErrorText = value;
                OnPropertyChanged(nameof(TbNameErrorText));
            }
        }

        private Visibility tbSurnameVisibility = Visibility.Collapsed;
        public Visibility TbSurnameErrorVisibility
        {
            get { return tbSurnameVisibility; }
            set
            {
                tbSurnameVisibility = value;
                OnPropertyChanged(nameof(TbSurnameErrorVisibility));
            }
        }

        private string tbSurnameErrorText;
        public string TbSurnameErrorText
        {
            get { return tbSurnameErrorText; }
            set
            {
                tbSurnameErrorText = value;
                OnPropertyChanged(nameof(TbSurnameErrorText));
            }
        }

        private Visibility tbUsernameVisibility = Visibility.Collapsed;
        public Visibility TbUsernameErrorVisibility
        {
            get { return tbUsernameVisibility; }
            set
            {
                tbUsernameVisibility = value;
                OnPropertyChanged(nameof(TbUsernameErrorVisibility));
            }
        }

        private string tbUsernameErrorText;
        public string TbUsernameErrorText
        {
            get { return tbUsernameErrorText; }
            set
            {
                tbUsernameErrorText = value;
                OnPropertyChanged(nameof(TbUsernameErrorText));
            }
        }

        private Visibility tbPasswordVisibility = Visibility.Collapsed;
        public Visibility TbPasswordErrorVisibility
        {
            get { return tbPasswordVisibility; }
            set
            {
                tbPasswordVisibility = value;
                OnPropertyChanged(nameof(TbPasswordErrorVisibility));
            }
        }

        private string tbPasswordErrorText;
        public string TbPasswordErrorText
        {
            get { return tbPasswordErrorText; }
            set
            {
                tbPasswordErrorText = value;
                OnPropertyChanged(nameof(TbPasswordErrorText));
            }
        }

        public List<string> Validate()
        {
            TbNameErrorVisibility = Visibility.Collapsed;
            TbSurnameErrorVisibility = Visibility.Collapsed;
            TbUsernameErrorVisibility = Visibility.Collapsed;
            TbPasswordErrorVisibility = Visibility.Collapsed;

            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(Name))
            {
                errors.Add("Name is required.");
                TbNameErrorVisibility = Visibility.Visible;
            }

            if (string.IsNullOrWhiteSpace(Surname))
            {
                errors.Add("Surname is required.");
                TbSurnameErrorVisibility = Visibility.Visible;
            }

            if (string.IsNullOrWhiteSpace(Username))
            {
                errors.Add("Username is required.");
                TbUsernameErrorVisibility = Visibility.Visible;

            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                errors.Add("Password is required.");
                TbPasswordErrorVisibility = Visibility.Visible;
            }

            return errors;
        }

        public void CreateProfile(object parameter)
        {
            List<string> errors = Validate();

            if (errors.Count == 0)
            {
                try
                {
                    DatabaseManager dbManager = new DatabaseManager();
                    dbManager.InsertUser(Name, Surname, Username, Password);
                    MessageBox.Show("Profile created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    ViewChanged?.Invoke(this, new EventArgs<string>("3"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while creating the profile: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                foreach (string error in errors)
                {
                    switch (error)
                    {
                        case "Name is required.":
                            TbNameErrorVisibility = Visibility.Visible;
                            TbNameErrorText = error;
                            break;
                        case "Surname is required.":
                            TbSurnameErrorVisibility = Visibility.Visible;
                            TbSurnameErrorText = error;
                            break;
                        case "Username is required.":
                            TbUsernameErrorVisibility = Visibility.Visible;
                            TbUsernameErrorText = error;
                            break;
                        case "Password is required.":
                            TbPasswordErrorVisibility = Visibility.Visible;
                            TbPasswordErrorText = error;
                            break;
                    }
                }
            }
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
    }
}
