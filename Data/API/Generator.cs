using Project_BlueLock.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Project_BlueLock.Data.API
{
    //public static class Generator
    //{
    //    public static List<Country> Generate()
    //    {
    //        const string ImageSource = "/Assets/Images/";
    //        List<string> pageContentList = GetPageContentList();

    //        var countries = new List<Country>
    //        {
    //                                new Country(ImageSource + "fr.jpg"),
    //                                new Country(ImageSource + "eng.jpg"),
    //                                new Country(ImageSource + "sp.jpg"),
    //                                new Country(ImageSource + "it.jpg"),
    //                                new Country(ImageSource + "ger.jpg")
    //                            };

    //        GeneratorTeamResult.Generate(countries, pageContentList);
    //        GeneratorTeamRanking.Generate(countries, pageContentList);
    //        //GeneratorPlayerRanking.Generate(countries, pageContentList);

    //        return countries;
    //    }

    //    private static List<string> GetPageContentList()
    //    {
    //        using (var client = new HttpClient())
    //        {
    //            var pageTaskList = new[]
    //                               {
    //                                   // Team result
    //                                   client.GetStringAsync("https://www.lequipe.fr/Football/ligue-1/page-calendrier-resultats"),
    //                                   client.GetStringAsync("https://www.lequipe.fr/Football/championnat-d-angleterre/page-calendrier-resultats"),
    //                                   client.GetStringAsync("https://www.lequipe.fr/Football/championnat-d-espagne/page-calendrier-resultats"),
    //                                   client.GetStringAsync("https://www.lequipe.fr/Football/championnat-d-italie/page-calendrier-resultats"),
    //                                   client.GetStringAsync("https://www.lequipe.fr/Football/championnat-d-allemagne/page-calendrier-resultats"),

    //                                   // Team ranking
    //                                   client.GetStringAsync("https://www.lequipe.fr/Football/ligue-1/page-classement-equipes/general"),
    //                                   client.GetStringAsync("https://www.lequipe.fr/Football/championnat-d-angleterre/page-classement-equipes/general"),
    //                                   client.GetStringAsync("https://www.lequipe.fr/Football/championnat-d-espagne/page-classement-equipes/general"),
    //                                   client.GetStringAsync("https://www.lequipe.fr/Football/championnat-d-italie/page-classement-equipes/general"),
    //                                   client.GetStringAsync("https://www.lequipe.fr/Football/championnat-d-allemagne/page-classement-equipes/general"),

    //                                   // Player ranking
    //                                   client.GetStringAsync("http://www.lequipe.fr/Football/FootballClassementChampionnat1914_BUT_1.html"),
    //                                   client.GetStringAsync("http://www.lequipe.fr/Football/FootballClassementChampionnat1909_BUT_1.html.html"),
    //                                   client.GetStringAsync("http://www.lequipe.fr/Football/FootballClassementChampionnat1907_BUT_1.html.html"),
    //                                   client.GetStringAsync("http://www.lequipe.fr/Football/FootballClassementChampionnat1905_BUT_1.html"),
    //                                   client.GetStringAsync("http://www.lequipe.fr/Football/FootballClassementChampionnat1911_BUT_1.html")
    //                               };

    //            Task.WaitAll(pageTaskList);
    //            return pageTaskList.Select(t => WebUtility.HtmlDecode(t.Result)).ToList();
    //        }
    //    }
    //}
}
