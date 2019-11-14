﻿using System.Collections.Generic;
using PairingAlgorithms.Models;

namespace PairingAlgorithms.Systems
{
    public interface IPairing
    {
        List<List<Player>> Pair(List<Player> Players);
    }
}
