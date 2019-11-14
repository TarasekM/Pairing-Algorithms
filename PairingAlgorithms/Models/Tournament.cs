using System.Collections.Generic;
using PairingAlgorithms.Systems;

namespace PairingAlgorithms.Models
{
    public class Tournament //TODO Make it abstract || Add methods like printScoreboard / remove Players etc.
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public Pairing PairingSystem { get; set; }
        public List<Player> Players { get; set; }

        public Tournament(PairingFactory.PairingSystems PairingSystem)
        {
            this.Players = Players;
            this.PairingSystem = PairingFactory.GetPairing(PairingSystem);
            this.Name = "Name not given";
            this.Date = "Date not given";
        }

        public void Pair()
        {
            PairingSystem.Pair(Players);
        }
    }
}
