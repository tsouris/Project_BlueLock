using Project_BlueLock.Utilities;
using System;

namespace Project_BlueLock.ViewModels
{
    public interface IPageViewModel
    {
        event EventHandler<EventArgs<string>>? ViewChanged;
        string PageId { get; set; }
        string Title { get; set; }
    }
}
