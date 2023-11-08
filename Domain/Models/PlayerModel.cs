using System;

namespace Project_BlueLock.Domain.Models
{
    public class PlayerModel
    {
        public int ID { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Country { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public int Shooting { get; set; }
        public int Dribbling { get; set; }
        public int Passing { get; set; }
        public int Physical { get; set; }
        public int Touch { get; set; }
        public int Pace { get; set; }
        public string ImagePath { get; set; }
    }
}
