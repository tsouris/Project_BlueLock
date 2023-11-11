using Project_BlueLock.Domain.Models;
using Project_BlueLock.Models;
using Project_BlueLock.Utilities;
using System;

namespace Project_BlueLock.ViewModels
{
    public class ProfileContentVM : BaseVM, IPageViewModel
    {
        private UserModel _user;
        private PlayerModel _player;

        public UserModel User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public PlayerModel Player
        {
            get => _player;
            set
            {
                _player = value;
                OnPropertyChanged(nameof(Player));
            }
        }

        public string PageId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler<EventArgs<string>>? ViewChanged;

        public ProfileContentVM(UserModel user = null, PlayerModel player = null)
        {
            User = user ?? new UserModel(); 
            Player = player ?? new PlayerModel();
        }
    }
}
