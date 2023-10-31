using Project_BlueLock.Utilities;
using System;
using System.Windows.Input;

namespace Project_BlueLock.ViewModels
{
    class HomeVM : BaseVM, IPageViewModel
    {
        private ICommand? _goToCreateProfile;
        public event EventHandler<EventArgs<string>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; } = "View 5";

        public HomeVM(string pageIndex = "5")
        {
            PageId = pageIndex;
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
    }
}
