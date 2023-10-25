using Project_BlueLock.Utilities;
using System.Windows.Input;

namespace Project_BlueLock.ViewModels
{
    public class RegistrationViewModel : Utilities.ViewModelBase
    {
        private NavigationVM _navigation;
        public ICommand ShowCreateProfileCommand { get; set; }

        public RegistrationViewModel(NavigationVM navigation)
        {
            _navigation = navigation;
            ShowCreateProfileCommand = new RelayCommand(ShowCreateProfile);
        }

        public RegistrationViewModel()
        {
        }

        private void ShowCreateProfile(object obj)
        {
            _navigation.CreateProfileCommand.Execute(null);
        }
    }
}



