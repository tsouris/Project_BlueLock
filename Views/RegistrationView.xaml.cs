using System.Windows.Controls;

namespace Project_BlueLock.Views
{
    /// <summary>
    /// Interaction logic for RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : UserControl
    {
        public RegistrationView()
        {
            InitializeComponent();
            lottieBG.FileName = @"C:\\Users\\User\\source\\repos\\Project_BlueLock\\Assets\\Animations\\Animation_1.json";
            lottieBG.PlayAnimation();
        }
    }
}
