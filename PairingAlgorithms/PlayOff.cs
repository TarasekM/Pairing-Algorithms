using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlatformForChessMatchmaking.Models;

namespace PlatformForChessMatchmaking.Algorithms
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
