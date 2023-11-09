using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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

        //private void btnChooseImage_Click(object sender, RoutedEventArgs e)
        //{
        //    Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
        //    openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All Files (*.*)|*.*";

        //    bool? result = openFileDialog.ShowDialog();

        //    if (result == true)
        //    {
        //        // Get the selected file path
        //        string filePath = openFileDialog.FileName;

        //        // Load the selected image
        //        BitmapImage bitmap = new BitmapImage(new Uri(filePath));
        //        selectedImage.Source = bitmap;
        //    }
        //}

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
