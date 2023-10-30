using Project_BlueLock.Utilities;
using System;
using System.Windows.Input;

namespace Project_BlueLock.ViewModels
{
    public class LoginVM : BaseVM, IPageViewModel
    {
        private ICommand? _goToCreateProfilePage;
        private ICommand? _goToRegistrationPage;
        private ICommand? _goToHomePage;

        public event EventHandler<EventArgs<string>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; } = "View 3";

        public LoginVM(string pageIndex = "3")
        {
            PageId = pageIndex;
        }

        public ICommand GoToCreateProfile
        {
            get
            {
                return _goToCreateProfilePage ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "2");
                });
            }
        }

        public ICommand GoToRegistration
        {
            get
            {
                return _goToRegistrationPage ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "1");
                });
            }
        }

        public ICommand GoToHome
        {
            get
            {
                return _goToHomePage ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "5");
                });
            }
        }
    }
}
