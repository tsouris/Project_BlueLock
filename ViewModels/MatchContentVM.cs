using Project_BlueLock.Domain.Models;
using Project_BlueLock.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows;

namespace Project_BlueLock.ViewModels
{
    class MatchContentVM : BaseVM, IPageViewModel
    {
        public string PageId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler<EventArgs<string>>? ViewChanged;

        public ObservableCollection<ScoreModel> Scores { get; set; }

        // Constructor
        public MatchContentVM()
        {
            LoadScoresAsync();
            Scores = new ObservableCollection<ScoreModel>();
            
        }

        private async void LoadScoresAsync()
        {
            try
            {
                string url = "https://www.flashscore.com/football/england/premier-league/#/I3O5jpB2/live";
                HttpClient client = new HttpClient();
                string html = await client.GetStringAsync(url);

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                // Use XPath or other selectors to locate the scores in the HTML
                // For example, if the scores are in a table with class "live-table", you might do:
                var scoreNodes = doc.DocumentNode.SelectNodes("//table[@class='live-table']//tr");

                if (scoreNodes != null)
                {
                    foreach (var node in scoreNodes)
                    {
                        string homeTeam = node.SelectSingleNode(".//td[@class='home']")?.InnerText.Trim();
                        string awayTeam = node.SelectSingleNode(".//td[@class='away']")?.InnerText.Trim();

                        if (!string.IsNullOrWhiteSpace(homeTeam) && !string.IsNullOrWhiteSpace(awayTeam))
                        {
                            Scores.Add(new ScoreModel { HomeTeam = homeTeam, AwayTeam = awayTeam });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
