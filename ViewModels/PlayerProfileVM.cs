using Project_BlueLock.Utilities;
using System;
using System.Windows.Input;

namespace Project_BlueLock.ViewModels
{
    class PlayerProfileVM : BaseVM, IPageViewModel
    {
        private ICommand? _goToHomePage;

        public event EventHandler<EventArgs<string>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; } = "View 4";

        public PlayerProfileVM(string pageIndex = "4")
        {
            PageId = pageIndex;
        }

        public ICommand GoToHomePage
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
