using Project_BlueLock.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Project_BlueLock.Data.API
{
    //public static class GeneratorTeamRanking
    //{
    //    public static void Generate(List<Country> countries, List<string> pageContentList)
    //    {
    //        // Modify the index to match the new URL
    //        countries[0].TeamRanking = GetTeamRanking(pageContentList[0]);
    //    }

    //    private static List<TeamRanking> GetTeamRanking(string pageContent)
    //    {
    //        var teamList = Regex.Matches(pageContent, @"<td class=""team"">.*?<img.*?alt=""(.*?)"".*?</td>", RegexOptions.IgnoreCase);

    //        var pointList = Regex.Matches(pageContent, @"<td class=""points"">(.*?)</td>", RegexOptions.IgnoreCase);
    //        var dayList = Regex.Matches(pageContent, @"<td class=""day"">(.*?)</td>", RegexOptions.IgnoreCase);
    //        var differenceList = Regex.Matches(pageContent, @"<td class=""difference"">(.*?)</td>", RegexOptions.IgnoreCase);

    //        var teamRankingList = new List<TeamRanking>();

    //        for (int i = 0; i < teamList.Count; i++)
    //        {
    //            teamRankingList.Add(new TeamRanking
    //            {
    //                TeamName = teamList[i].Groups[1].ToString(),
    //                Image = "", // You may need to find a way to get the team logos from this page
    //                Point = pointList[i].Groups[1].ToString(),
    //                Day = dayList[i].Groups[1].ToString(),
    //                Difference = differenceList[i].Groups[1].ToString()
    //            });
    //        }

    //        return teamRankingList;
    //    }
    //}
}
