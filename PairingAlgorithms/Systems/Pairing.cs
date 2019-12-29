using System.Collections.Generic;
using PairingAlgorithms.Models;

namespace PairingAlgorithms.Systems
{
    public abstract class Pairing : IPairing
    {
        public int CurrentRound { get; set; }
        public int MaxRound { get; set; }

        public abstract List<List<int>> Pair(List<Player> Players);
    }
}
