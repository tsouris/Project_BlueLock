using Project_BlueLock.Utilities;
using System;

namespace Project_BlueLock.ViewModels
{
    public class TrainingContentVM : BaseVM, IPageViewModel
    {
        public string PageId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler<EventArgs<string>>? ViewChanged;
    }
}
