using Project_BlueLock.ViewModels;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Project_BlueLock.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            DataContext = new HomeVM();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        //private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    WindowInteropHelper helper = new WindowInteropHelper(this);
        //    SendMessage(helper.Handle, 161, 2, 0);
        //}
        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.WindowState = WindowState.Minimized;
            }
        }

        //private void Button_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        //{
        //    userOptionsContextMenu.PlacementTarget = sender as UIElement;
        //    userOptionsContextMenu.IsOpen = true;
        //    e.Handled = true;
        //}

        //private void LogOut_Click(object sender, RoutedEventArgs e)
        //{
        //    LoginView loginView = new LoginView(); 
        //    Window.GetWindow(this).Content = loginView;
        //}

        //private void rbMatches_Click(object sender, RoutedEventArgs e)
        //{
        //    string competitionId = "CL"; // Replace with the desired competition ID

        //    Application.Current.Dispatcher.Invoke(async () =>
        //    {
        //        await ((HomeVM)DataContext).LoadMatchesAsync(competitionId);
        //    });
        //}
    }
}
