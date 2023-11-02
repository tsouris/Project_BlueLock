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

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void tbSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void tbUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            
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

        private void tbDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

    }
}
