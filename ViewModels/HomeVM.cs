using Project_BlueLock.Utilities;
using System;

namespace Project_BlueLock.ViewModels
{
    class HomeVM : BaseVM, IPageViewModel
    {
        public event EventHandler<EventArgs<string>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; } = "View 5";

        public HomeVM(string pageIndex = "5")
        {
            PageId = pageIndex;
        }
    }
}
