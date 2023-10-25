using Project_BlueLock.ViewModels;
using System.Windows.Controls;

namespace Project_BlueLock.Views
{
    /// <summary>
    /// Interaction logic for RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : UserControl
    {
        public NavigationVM Navigation { get; set; }
        public RegistrationView()
        {
            InitializeComponent();
            lottieBG.FileName = @"C:\\Users\\User\\source\\repos\\Project_BlueLock\\Assets\\Animations\\Animation_1.json";
            lottieBG.PlayAnimation();
        }

        public RegistrationView(NavigationVM navigation)
        {
            Navigation = navigation;
        }
    }
}
