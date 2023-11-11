using System.Collections.Generic;

namespace Project_BlueLock.Domain.Models
{
    public class ScoreboardModel
    {
        public string Time { get; set; }
        public string Date { get; set; } // Add this line for the date
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public string TeamAImage { get; set; } // Add this line for the team image
        public string TeamBImage { get; set; } // Add this line for the team image
        public string Score { get; set; }
        public List<string> GoalScorers { get; set; } = new List<string>();
    }
}
