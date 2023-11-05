using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Project_BlueLock.Data.API
{
    public  class FootballDataApiClient
    {
        public async Task<List<Match>> GetMatchesAsync(string competitionId)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiKey = "485f82f5056f4a5eb363344751ff6956";
                string apiUrl = "https://api.football-data.org/v4/matches";

                client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);

                try
                {
                    HttpResponseMessage response = await client.GetAsync($"{apiUrl}?competitionId={competitionId}");

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(content);
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
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return new List<Match>(); // or display a message to the user
                    }
                    else
                    {
                        throw new Exception($"Error fetching matches from API. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw; // Re-throw the exception to propagate it up the call stack
                }
            }
        }

        public async Task<List<Team>> GetTeamsAsync(string competitionId)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiKey = "485f82f5056f4a5eb363344751ff6956";
                string apiUrl = "https://api.football-data.org/v4/teams";

                client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);

                try
                {
                    HttpResponseMessage response = await client.GetAsync($"{apiUrl}?competitionId={competitionId}");

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(content);
                        TeamResponse teamResponse = JsonConvert.DeserializeObject<TeamResponse>(content);

                        if (teamResponse != null && teamResponse.Teams != null)
                        {
                            return teamResponse.Teams;
                        }
                        else
                        {
                            throw new Exception("Error: Unable to parse API response.");
                        }
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return new List<Team>(); // or display a message to the user
                    }
                    else
                    {
                        throw new Exception($"Error fetching teams from API. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw; // Re-throw the exception to propagate it up the call stack
                }
            }
        }
    }
}
