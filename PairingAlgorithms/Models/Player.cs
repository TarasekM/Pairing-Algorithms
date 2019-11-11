using System;
using System.Collections.Generic;
using System.Text;

namespace PlatformForChessMatchmaking.Models { 
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Score { get; set; }

        public int TotalGames { get; set; }
        public int GamesAsWhite { get; set; }
        public int GamesAsBlack { get; set; }

        public bool HaveOponent { get; set; }
        public int CurrentOpponentID { get; set; }

        public Player(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
            Score = 0;
            TotalGames = 0;
            GamesAsWhite = 0;
            GamesAsBlack = 0;
            HaveOponent = false;
        }

        override public string ToString()
        {
            return ID + ". " + Name; 
        }
    }
}
