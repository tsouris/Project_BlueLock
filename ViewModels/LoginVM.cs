using Project_BlueLock.Data;
using Project_BlueLock.Utilities;
using System;
using System.Text;
using System.Windows.Input;
using System.Security.Cryptography;
using System.Windows;

namespace Project_BlueLock.ViewModels
{
    public class LoginVM : BaseVM, IPageViewModel
    {
        private ICommand? _goToCreateProfilePage;
        private ICommand? _goToHomePage;

        public event EventHandler<EventArgs<string>>? ViewChanged;

        public event EventHandler SuccessfulLogin;

        public string PageId { get; set; }
        public string Title { get; set; } = "View 2";

        public LoginVM(string pageIndex = "2")
        {
            PageId = pageIndex;
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
            //public ICommand GoToHomePage
            //{
            //    get
            //    {
            //        return _goToHomePage ??= new RelayCommand(x =>
            //        {
            //            string passwordHash = CalculateHash(Password);

            //            if (ValidateCredentials(Username, passwordHash))
            //            {
            //                SuccessfulLogin?.Invoke(this, EventArgs.Empty);
            //            }
            //            else
            //            {
            //                //tbPasswordError.Visibility = Visibility.Visible;
            //            }
            //        });
            //    }
            //}

            //private readonly DatabaseManager databaseManager = new DatabaseManager();

            //private string CalculateHash(string input)
            //{
            //    using (SHA256 sha256 = SHA256Managed.Create())
            //    {
            //        byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            //        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            //    }
            //}

            //private bool ValidateCredentials(string username, string password)
            //{
            //    string passwordHash = CalculateHash(password); // You need to implement a hashing function
            //    return databaseManager.CheckUserCredentials(username, passwordHash);
            //}
        }
}
