using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BlueLock.Domain.Models
{
    public class MatchListResponse
    {
        public int Count { get; set; }
        public List<FootballMatch> Matches { get; set; }
    }
}
