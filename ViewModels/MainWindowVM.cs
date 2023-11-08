using Project_BlueLock.Interfaces;
using System.Collections.Generic;

namespace Project_BlueLock.ViewModels
{
    public class MainWindowVM : BaseVM
    {
        private IPageViewModel? _pageViewModel;
        private readonly Dictionary<string, IPageViewModel>? _pageViewModels = new();

        public IPageViewModel? CurrentPageViewModel
        {
            get
            {
                return _pageViewModel;
            }
            set
            {
                _pageViewModel = value;
                OnPropertyChanged(nameof(CurrentPageViewModel));
            }
        }

        public MainWindowVM(IDataModel pageViews)
        {
            _pageViewModels["1"] = new CreateProfileVM("1");
            _pageViewModels["1"].ViewChanged += (o, s) =>
            {
                CurrentPageViewModel = _pageViewModels[s.Value];
                pageViews.Data = "Data: " + s.Value.ToString();
            };

            _pageViewModels["2"] = new LoginVM("2");
            _pageViewModels["2"].ViewChanged += (o, s) =>
            {
                CurrentPageViewModel = _pageViewModels[s.Value];
                pageViews.Data = "Data: " + s.Value.ToString();
            };

            _pageViewModels["3"] = new PlayerProfileVM("3");
            _pageViewModels["3"].ViewChanged += (o, s) =>
            {
                CurrentPageViewModel = _pageViewModels[s.Value];
                pageViews.Data = "Data: " + s.Value.ToString();
            };

            _pageViewModels["4"] = new HomeVM("4");
            _pageViewModels["4"].ViewChanged += (o, s) =>
            {
                CurrentPageViewModel = _pageViewModels[s.Value];
                pageViews.Data = "Data: " + s.Value.ToString();
            };

            CurrentPageViewModel = _pageViewModels["3"];
        }
    }
}
