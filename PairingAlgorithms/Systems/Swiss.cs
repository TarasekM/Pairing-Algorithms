using System;
using System.Collections.Generic;
using PairingAlgorithms.Models;

namespace PairingAlgorithms.Systems
{
    public class Swiss : Pairing
    {
        public Swiss(List<Player> Players) : base(Players)
        {
        }

        public override List<Player> Pair()
        {
            throw new NotImplementedException();
        }
    }
}
