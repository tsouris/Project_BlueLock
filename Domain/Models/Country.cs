using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BlueLock.Domain.Models
{
    public class Country
    {
        public Country(string image)
        {
            Image = image;
        }

        public string Image { get; set; }
        public List<TeamRanking> TeamRanking { get; set; }
        public List<PlayerRanking> PlayerRanking { get; set; }
        public List<TeamResult> TeamResult { get; set; }
    }
}
