using Project_BlueLock.Data.API;
using Project_BlueLock.Utilities;
using System;
using System.Collections.Generic;

namespace Project_BlueLock.ViewModels
{
    class MatchContentVM : BaseVM, IPageViewModel
    {
        public string PageId { get; set; }
        public string Title { get; set; }

        public event EventHandler<EventArgs<string>>? ViewChanged;

        private List<Match> _matches;

        public List<Match> Matches
        {
            get { return _matches; }
            set
            {
                _matches = value;
                OnPropertyChanged(nameof(Matches));
            }
        }

        public MatchContentVM()
        {
            PageId = "4";
            Title = "View 4";

            LoadMatches();
        }

        private async void LoadMatches()
        {
            try
            {
                FootballAPIClient client = new FootballAPIClient("LzykmoIpGFzzEM8XVKaFVcYazNpH0nH4N2ivlRiFihW7tJIdRgXFfqAK3fp5"); // Replace with your API key
                Matches = await client.GetMatchesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
