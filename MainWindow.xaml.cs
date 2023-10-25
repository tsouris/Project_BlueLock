using Project_BlueLock.ViewModels;
using System.Windows;

namespace Project_BlueLock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new NavigationVM();
        }
    }
}
