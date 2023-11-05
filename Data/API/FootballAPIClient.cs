using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Project_BlueLock.Data.API
{
    public class FootballAPIClient
    {
        private readonly string _apiKey;

        public FootballAPIClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<List<Match>> GetMatchesAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://api.football-api.com/2.0/matches";

                client.DefaultRequestHeaders.Add("x-api-key", _apiKey);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        MatchResponse matchResponse = JsonConvert.DeserializeObject<MatchResponse>(content);

                        if (matchResponse != null && matchResponse.Matches != null)
                        {
                            return matchResponse.Matches;
                        }
                        else
                        {
                            throw new Exception("Error: Unable to parse API response.");
                        }
                    }
                    else
                    {
                        throw new Exception($"Error fetching matches from API. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
