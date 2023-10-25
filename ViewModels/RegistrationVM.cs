using Project_BlueLock.Utilities;
using System;
using System.Windows.Input;

namespace Project_BlueLock.ViewModels
{
    public class RegistrationVM : IPageViewModel
    {
        private ICommand? _goToCreateProfile;
        private ICommand? _goToLogin;

        public event EventHandler<EventArgs<string>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }

        public RegistrationVM(string pageIndex = "1")
        {
            PageId = pageIndex;
            Title = "View 1";
        }
        public ICommand GoToCreateProfile
        {
            get
            {
                return _goToCreateProfile ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "2");
                });
            }
        }

        public ICommand GoToLogin
        {
            get
            {
                return _goToLogin ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "3");
                });
            }
        }
    }
}



