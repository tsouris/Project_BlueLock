using HtmlAgilityPack;
using Project_BlueLock.Domain.Models;
using Project_BlueLock.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace Project_BlueLock.ViewModels
{
    class MatchContentVM : BaseVM, IPageViewModel
    {
        public string PageId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler<EventArgs<string>>? ViewChanged;

        public ObservableCollection<ScoreboardModel> Scoreboards { get; set; } = new ObservableCollection<ScoreboardModel>();

        public MatchContentVM()
        {
            ScrapeScoreboardsAsync();
        }

        public async Task ScrapeScoreboardsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://football.ua/scoreboard/";
                string htmlContent = await client.GetStringAsync(url);

                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(htmlContent);

                var matchNodes = htmlDocument.DocumentNode.SelectNodes("//div[@class='match']");

                if (matchNodes != null)
                {
                    foreach (var node in matchNodes)
                    {
                        ScoreboardModel scoreboard = new ScoreboardModel();

                        // Match Time
                        scoreboard.Time = node.SelectSingleNode(".//td[@class='time']/a")?.InnerText;

                        // Team A
                        scoreboard.TeamA = node.SelectSingleNode(".//td[@class='left-team']/a")?.InnerText;

                        // Team A Image
                        scoreboard.TeamAImage = node.SelectSingleNode(".//td[@class='left-team']/span/img")?.GetAttributeValue("src", "");

                        // Team B
                        scoreboard.TeamB = node.SelectSingleNode(".//td[@class='right-team']/a")?.InnerText;

                        // Team B Image
                        scoreboard.TeamBImage = node.SelectSingleNode(".//td[@class='right-team']/span/img")?.GetAttributeValue("src", "");

                        // Score
                        scoreboard.Score = node.SelectSingleNode(".//td[@class='score']/a")?.InnerText;

                        Scoreboards.Add(scoreboard);
                    }
                }
            }
        }
    }
}
