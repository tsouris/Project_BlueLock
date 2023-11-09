using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Project_BlueLock.Domain.Models
{
    public class FootballMatch
    {
        public int Id { get; set; }
        public Team HomeTeamName { get; set; }
        public Team AwayTeamName { get; set; }
        public Score Score { get; set; }
        // Add other properties as needed
    }
}
