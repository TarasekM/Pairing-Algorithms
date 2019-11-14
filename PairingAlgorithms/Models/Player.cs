
using System;

namespace PairingAlgorithms.Models { 
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

        public override string ToString()
        {
            return ID + ". " + Name;
        }

        public override bool Equals(object obj)
        {
            Player other = (Player)obj;
            if(
                this.ID == other.ID &&
                this.Name == other.Name &&
                this.Score == other.Score &&
                this.TotalGames == other.TotalGames &&
                this.GamesAsWhite == other.GamesAsWhite &&
                this.GamesAsBlack == other.GamesAsBlack &&
                this.HaveOponent == other.HaveOponent
                ){
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Name, Score, TotalGames, GamesAsWhite, GamesAsBlack, HaveOponent, CurrentOpponentID);
        }
    }
}
