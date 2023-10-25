namespace Project_BlueLock.ViewModels
{
    class LoginViewModel : Utilities.ViewModelBase
    {
        public NavigationVM Navigation { get; set; }

        public LoginViewModel(NavigationVM navigation)
        {
            Navigation = navigation;
        }

        public LoginViewModel()
        {
        }
    }
}
