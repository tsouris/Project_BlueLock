using HtmlAgilityPack;
using Newtonsoft.Json;
using Project_BlueLock.Domain.Models;
using Project_BlueLock.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project_BlueLock.ViewModels
{
    class MatchContentVM : BaseVM, IPageViewModel
    {
        public string PageId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler<EventArgs<string>>? ViewChanged;

        //public ObservableCollection<FootballMatch> Matches { get; set; }

        public ObservableCollection<ScoreboardModel> Scoreboards { get; set; } = new ObservableCollection<ScoreboardModel>();
        // Constructor
        public MatchContentVM()
        {
            // Call method to fetch match data
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

                        var timeNode = node.SelectSingleNode(".//td[@class='time']/a");
                        if (timeNode != null)
                        {
                            scoreboard.Time = timeNode.InnerText;
                        }

                        var leftTeamNode = node.SelectSingleNode(".//td[@class='left-team']/a");
                        if (leftTeamNode != null)
                        {
                            scoreboard.TeamA = leftTeamNode.InnerText;
                        }

                        var rightTeamNode = node.SelectSingleNode(".//td[@class='right-team']/a");
                        if (rightTeamNode != null)
                        {
                            scoreboard.TeamB = rightTeamNode.InnerText;
                        }

                        var scoreNode = node.SelectSingleNode(".//td[@class='score inprogress']/a");
                        if (scoreNode != null)
                        {
                            scoreboard.Score = scoreNode.InnerText;
                        }

                        // Goal Scorers
                        var goalNodes = node.SelectNodes(".//table[@class='goals-table']/tbody/tr");
                        if (goalNodes != null)
                        {
                            foreach (var goalNode in goalNodes)
                            {
                                var scorerNode = goalNode.SelectSingleNode(".//td[@class='right']/span/b");
                                if (scorerNode != null)
                                {
                                    scoreboard.GoalScorers.Add(scorerNode.InnerText);
                                }
                            }
                        }

                        Scoreboards.Add(scoreboard);
                    }
                }
            }
        }
    }
}
