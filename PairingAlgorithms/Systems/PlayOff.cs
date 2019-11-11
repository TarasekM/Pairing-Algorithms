using System;
using System.Collections.Generic;
using PairingAlgorithms.Models;

namespace PairingAlgorithms.Systems
{
    public class PlayOff : Pairing
    {
        public PlayOff(List<Player> Players) : base(Players)
        {
        }

        public override List<Player> Pair()
        {
            throw new NotImplementedException();
        }
    }
}
