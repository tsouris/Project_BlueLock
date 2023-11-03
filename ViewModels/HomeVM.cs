using FontAwesome.Sharp;
using Project_BlueLock.Utilities;
using System;
using System.Windows.Input;

namespace Project_BlueLock.ViewModels
{
    class HomeVM : BaseVM, IPageViewModel
    {
        public event EventHandler<EventArgs<string>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; } = "View 4";

        private BaseVM _currentChildView;

        private string _caption;

        private IconChar _icon;

        public BaseVM CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        public ICommand ShowHomeContentCommand { get; }

        public ICommand ShowMatchContentCommand { get; }

        public ICommand ShowTrainingContentCommand { get; }

        public ICommand ShowProfileContentCommand { get; }

        public HomeVM(string pageIndex = "4")
        {
            PageId = pageIndex;

            ShowHomeContentCommand = new RelayCommand(ExecuteShowHomeContentCommand);

            ShowMatchContentCommand = new RelayCommand(ExecuteShowMatchContentCommand);

            ShowTrainingContentCommand = new RelayCommand(ExecuteShowTrainingContentCommand);

            ShowProfileContentCommand = new RelayCommand(ExecuteShowProfileContentCommand);

            ExecuteShowHomeContentCommand(null);
        }

        private void ExecuteShowHomeContentCommand(object obj)
        {
            CurrentChildView = new HomeContentVM();
            Caption = "Home";
            Icon = IconChar.Home;
        }

        private void ExecuteShowMatchContentCommand(object obj)
        {
            CurrentChildView = new MatchContentVM();
            Caption = "Match";
            Icon = IconChar.SoccerBall;
        }

        private void ExecuteShowTrainingContentCommand(object obj)
        {
            CurrentChildView = new TrainingContentVM();
            Caption = "Training";
            Icon = IconChar.Dumbbell;
        }

        private void ExecuteShowProfileContentCommand(object obj)
        {
            CurrentChildView = new ProfileContentVM();
            Caption = "Profile";
            Icon = IconChar.User;
        }

        //private List<Match> _matches;
        //public List<Match> Matches
        //{
        //    get { return _matches; }
        //    set
        //    {
        //        _matches = value;
        //        OnPropertyChanged(nameof(Matches));
        //    }
        //}

        //public async Task LoadMatchesAsync(string competitionId)
        //{
        //    try
        //    {
        //        FootballDataApiClient apiClient = new FootballDataApiClient();
        //        Matches = await apiClient.GetMatchesAsync(competitionId);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
