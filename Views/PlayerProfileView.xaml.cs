using System.Windows;
using System.Windows.Controls;

namespace Project_BlueLock.Views
{
    /// <summary>
    /// Interaction logic for PlayerProfileView.xaml
    /// </summary>
    public partial class PlayerProfileView : UserControl
    {
        public PlayerProfileView()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.WindowState = WindowState.Minimized;
            }
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                if (parentWindow.WindowState == WindowState.Maximized)
                {
                    parentWindow.WindowState = WindowState.Normal;
                }
                else
                {
                    parentWindow.WindowState = WindowState.Maximized;
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
