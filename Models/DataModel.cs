using Project_BlueLock.Interfaces;
using System;

namespace Project_BlueLock.Models
{
    public class DataModel : IDataModel
    {
        public string Data { get; set; }
        public string? Reverse()
        {
            char[] charArray = Data.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public DataModel()
        {
            Data = "";
        }

        public DataModel(string data)
        {
            Data = data;
        }
    }
}
