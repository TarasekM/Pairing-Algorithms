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

        public Tournament(string Name, string Date, PairingFactory.PairingSystems PairingSystem)
        {
            this.PairingSystem = PairingFactory.GetPairing(PairingSystem);
            this.Name = Name;
            this.Date = Date;
        }

        public void Pair()
        {
            List<List<Player>> Pairings = PairingSystem.Pair(Players);
        }

        public abstract void GetScoreboard();

        public abstract void RemovePlayer();

        public abstract void AddPlayer();
    }
}
