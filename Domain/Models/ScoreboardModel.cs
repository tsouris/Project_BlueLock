using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BlueLock.Domain.Models
{
    public class ScoreboardModel
    {
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public string Score { get; set; }
        public string Time { get; set; }
        public List<string> GoalScorers { get; set; } = new List<string>();

    }
}
