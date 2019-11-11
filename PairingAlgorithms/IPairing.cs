using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlatformForChessMatchmaking.Models;

namespace PlatformForChessMatchmaking.Algorithms
{
    public interface IPairing
    {
        List<Player> Pair();
    }
}
