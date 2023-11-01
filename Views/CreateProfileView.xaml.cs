using Project_BlueLock.Data;
using Project_BlueLock.Utilities;
using Project_BlueLock.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Project_BlueLock.Views
{
    /// <summary>
    /// Interaction logic for CreateProfileView.xaml
    /// </summary>
    public partial class CreateProfileView : UserControl
    {
        public CreateProfileView()
        {
            InitializeComponent();
            DataContext = new CreateProfileVM();
        }

        private void CreateProfileButton_Click(object sender, RoutedEventArgs e)
        {
            CreateProfileVM viewModel = (CreateProfileVM)DataContext;
            List<string> errors = viewModel.Validate();

            if (errors.Count == 0)
            {
                try
                {
                    DatabaseManager dbManager = new DatabaseManager();
                    dbManager.InsertUser(tbName.Text, tbSurname.Text, tbUsername.Text, pbPassword.Password);
                    MessageBox.Show("Profile created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while creating the profile: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                foreach (string error in errors)
                {
                    switch (error)
                    {
                        case "Name is required.":
                            tbNameError.Visibility = Visibility.Visible;
                            tbNameError.Text = error;
                            break;
                        case "Surname is required.":
                            tbSurnameError.Visibility = Visibility.Visible;
                            tbSurnameError.Text = error;
                            break;
                        case "Username is required.":
                            tbUsernameError.Visibility = Visibility.Visible;
                            tbUsernameError.Text = error;
                            break;
                        case "Password is required.":
                            tbPasswordError.Visibility = Visibility.Visible;
                            tbPasswordError.Text = error;
                            break;
                    }
                }
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

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.WindowState = WindowState.Minimized;
            }
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine("TextChanged event triggered.");
            // Add a breakpoint here to verify if this code is reached
            tbNameError.Visibility = Visibility.Collapsed;
            tbNameError.Text = string.Empty;
        }

        
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("TextChanged event triggered.");
            // Add a breakpoint here to verify if this code is reached
            tbPasswordError.Visibility = Visibility.Collapsed;
            tbPasswordError.Text = string.Empty;
        }

        private void tbSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine("TextChanged event triggered.");
            // Add a breakpoint here to verify if this code is reached
            tbSurnameError.Visibility = Visibility.Collapsed;
            tbSurnameError.Text = string.Empty;
        }

        private void tbUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine("TextChanged event triggered.");
            // Add a breakpoint here to verify if this code is reached
            tbUsernameError.Visibility = Visibility.Collapsed;
            tbUsernameError.Text = string.Empty;
        }
    }
}
