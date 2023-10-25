using Project_BlueLock.Utilities;
using System.Windows.Input;

namespace Project_BlueLock.ViewModels
{
    public class NavigationVM : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public NavigationVM Navigation { get; set; }
        public ICommand RegistrationCommand { get; set; }
        public ICommand CreateProfileCommand { get; set; }
        public ICommand LoginCommand { get; set; }

        private void Registration(object obj) => CurrentView = new RegistrationViewModel();
        private void CreateProfile(object obj) => CurrentView = new CreateProfileViewModel(Navigation);
        private void Login(object obj) => CurrentView = new LoginViewModel();

        public NavigationVM()
        {
            RegistrationCommand = new RelayCommand(Registration);
            CreateProfileCommand = new RelayCommand(CreateProfile);
            LoginCommand = new RelayCommand(Login);

            CurrentView = new RegistrationViewModel();
            Navigation = this;
        }
    }
}
