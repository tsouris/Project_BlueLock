using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BlueLock.Domain.Models
{
    public class Match
    {
        public Area Area { get; set; }
        public Competition Competition { get; set; }
        public Season Season { get; set; }
        public int Id { get; set; }
        // Add other properties as needed
    }
}
