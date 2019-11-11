using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlatformForChessMatchmaking.Algorithms;

namespace PlatformForChessMatchmaking.Models
{
    public class Tournament
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public Pairing PairingSystem { get; set; }
        public List<Player> Players { get; set; }

        public Tournament(PairingFactory.PairingSystems PairingSystem)
        {
            this.PairingSystem = PairingFactory.GetPairing(PairingSystem, Players);
        }

        public void Pair()
        {
            PairingSystem.Pair();
        }
    }
}
