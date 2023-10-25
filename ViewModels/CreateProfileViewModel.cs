namespace Project_BlueLock.ViewModels
{
    public class CreateProfileViewModel : Utilities.ViewModelBase
    {
        public NavigationVM Navigation { get; set; }
        public CreateProfileViewModel(NavigationVM navigation)
        {
            Navigation = navigation;
        }
    }
}
