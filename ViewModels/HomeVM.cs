using FontAwesome.Sharp;
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
        public string Title { get; set; } = "View 4";

        //New
        private BaseVM _currentChildView;
        private string _caption;
        private IconChar _icon;

        //New
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

        //New
        public ICommand ShowHomeContentCommand { get; }
        public ICommand ShowMatchContentCommand { get; }
        public ICommand ShowProfileContentCommand { get; }
        public ICommand ShowTrainingContentCommand { get; }


        public HomeVM(string pageIndex = "4")
        {
            PageId = pageIndex;

            //New
            ShowHomeContentCommand = new RelayCommand(ExecuteShowHomeContentCommand);
            ShowMatchContentCommand = new RelayCommand(ExecuteShowMatchContentCommand);
            ShowProfileContentCommand = new RelayCommand(ExecuteShowProfileContentCommand);
            ShowTrainingContentCommand = new RelayCommand(ExecuteShowTrainingContentCommand);


            ExecuteShowHomeContentCommand(null);
        }

        //New
        private void ExecuteShowHomeContentCommand(object obj)
        {
            CurrentChildView = new HomeContentVM();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }

        private void ExecuteShowMatchContentCommand(object obj)
        {
            CurrentChildView = new MatchContentVM();
            Caption = "Match";
            Icon = IconChar.SoccerBall;
        }

        private void ExecuteShowProfileContentCommand(object obj)
        {
            CurrentChildView = new ProfileContentVM();
            Caption = "Profile";
            Icon = IconChar.User;
        }

        private void ExecuteShowTrainingContentCommand(object obj)
        {
            CurrentChildView = new TrainingContentVM();
            Caption = "Training";
            Icon = IconChar.Dumbbell;
        }

        public ICommand GoToCreateProfile
        {
            get
            {
                return _goToCreateProfile ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "1");
                });
            }
        }

        private string _title;
        public string TitleHome
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(TitleHome));
            }
        }

        private string _videoSource;
        public string VideoSource
        {
            get { return _videoSource; }
            set
            {
                _videoSource = value;
                OnPropertyChanged(nameof(VideoSource));
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
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
