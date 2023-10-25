using Project_BlueLock.Utilities;
using System;
using System.Windows.Input;

namespace Project_BlueLock.ViewModels
{
    public class CreateProfileVM : BaseVM, IPageViewModel
    {
        private ICommand? _goToLogin;
        private ICommand? _goToRegistration;
        public event EventHandler<EventArgs<string>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; } = "View 2";

        public CreateProfileVM(string pageIndex = "2")
        {
            PageId = pageIndex;
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

        public ICommand GoToRegistration
        {
            get
            {
                return _goToRegistration ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "1");
                });
            }
        }
    }
}
