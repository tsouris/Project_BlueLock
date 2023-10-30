using Project_BlueLock.Data;
using System;
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
        }

        private void CreateProfileButton_Click(object sender, RoutedEventArgs e)
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
    }
}
