using System;
using System.Windows;
using System.Windows.Controls;

namespace Project_BlueLock.Views
{
    /// <summary>
    /// Interaction logic for HomeContentView.xaml
    /// </summary>
    public partial class HomeContentView : UserControl
    {
        public HomeContentView()
        {
            InitializeComponent();
        }

        private bool isPlaying = false;
        private void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                mediaElement.Pause();
                isPlaying = false;
            }
            else
            {
                mediaElement.Play();
                isPlaying = true;
            }
        }
    }
}
