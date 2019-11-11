using System.Collections.Generic;
using PairingAlgorithms.Models;

namespace PairingAlgorithms.Systems
{
    public abstract class Pairing : IPairing
    {
        public List<Player> Players;
        public int CurrentRound { get; set; }

        public Pairing(List<Player> Players)
        {
            this.Players = Players;
            if (this.Players.Count % 2 == 1)
            {
                this.Players.Add(new Player(0, "Bye"));
            }

        }

        public abstract List<Player> Pair();
    }
}
