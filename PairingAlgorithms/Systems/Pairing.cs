using System.Collections.Generic;
using PairingAlgorithms.Models;

namespace PairingAlgorithms.Systems
{
    public abstract class Pairing : IPairing
    {
        public List<Player> Players;
        public int CurrentRound { get; set; }


        public abstract List<List<Player>> Pair(List<Player> Players);
    }
}
