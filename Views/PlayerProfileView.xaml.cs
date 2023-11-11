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

        private void tbHeight_TextChanged(object sender, TextChangedEventArgs e)
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

        private void tbWeight_TextChanged(object sender, TextChangedEventArgs e)
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

        private void tbBirthday_TextChanged(object sender, TextChangedEventArgs e)
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

        private void tbShooting_TextChanged(object sender, RoutedEventArgs e)
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

        private void tbDribbling_TextChanged(object sender, RoutedEventArgs e)
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

        private void tbPassing_TextChanged(object sender, RoutedEventArgs e)
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

        private void tbPhysical_TextChanged(object sender, RoutedEventArgs e)
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

        private void tbTouch_TextChanged(object sender, RoutedEventArgs e)
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

        private void tbPace_TextChanged(object sender, RoutedEventArgs e)
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
