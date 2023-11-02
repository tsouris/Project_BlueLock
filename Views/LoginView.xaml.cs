using System.Windows;
using System.Windows.Controls;

namespace Project_BlueLock.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.WindowState = WindowState.Minimized;
            }
        }

        private void btnMaximize_Click(object sender, System.Windows.RoutedEventArgs e)
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

        private void btnClose_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void pbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Tag is Visibility visibility)
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    visibility = Visibility.Collapsed;
                }
                else
                {
                    visibility = Visibility.Visible;
                }
            }
        }

        private void tbUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Tag is Visibility visibility)
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    visibility = Visibility.Collapsed;
                }
                else
                {
                    visibility = Visibility.Visible;
                }
            }
        }
    }
}
