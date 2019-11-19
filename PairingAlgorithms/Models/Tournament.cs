using System.Collections.Generic;
using PairingAlgorithms.Systems;

namespace PairingAlgorithms.Models
{
    public abstract class Tournament //TODO Make it abstract || Add methods like printScoreboard / remove Players etc.
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public Pairing PairingSystem { get; set; }
        public List<Player> Players { get; set; }
        public int CurrentRound { get; set; }

        public Tournament(string Name, string Date, PairingFactory.PairingSystems PairingSystem)
        {
            this.PairingSystem = PairingFactory.GetPairing(PairingSystem);
            this.Name = Name;
            this.Date = Date;
        }

        public void Pair()
        {
            List<List<int>> Pairings = PairingSystem.Pair(Players);
            foreach (List<int> Pair in Pairings)
            {
                int white = Pair[0];
                int black = Pair[1];

                Players.Find(p => p.ID == white)
                    .Pair(Players.Find(p => p.ID == black));
            }
        }

        public void StartTournament()
        {
            if (Players.Count % 2 == 1)
            {
                Players.Add(Player.GetByePlayer());
            }
        }

        public abstract void GetScoreboard();

        public abstract void RemovePlayer();

        public abstract void AddPlayer();
    }
}
