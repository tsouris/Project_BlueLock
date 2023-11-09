using Microsoft.VisualBasic.ApplicationServices;
using Project_BlueLock.Data.DB;
using Project_BlueLock.Models;
using Project_BlueLock.Utilities;
using System;

namespace Project_BlueLock.ViewModels
{
    public class ProfileContentVM : BaseVM, IPageViewModel
    {
        public string PageId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler<EventArgs<string>>? ViewChanged;

        // Assuming you have a property to hold the user's information
        private UserModel _user;

        public UserModel User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public ProfileContentVM()
        {

        }
    }
}
