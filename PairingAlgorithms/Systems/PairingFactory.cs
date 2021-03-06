﻿using System.Collections.Generic;
using PairingAlgorithms.Models;

namespace PairingAlgorithms.Systems
{
    public class PairingFactory
    {

        public enum PairingSystems
        {
            RoundRobin,
            PlayOff,
            Swiss,
        }

        public static Pairing GetPairing(PairingSystems System, List<Player> Players)
        {
            switch (System)
            {
                case PairingSystems.RoundRobin:
                    return new RoundRobin(Players);
                case PairingSystems.PlayOff:
                    return new PlayOff();
                case PairingSystems.Swiss:
                    return new Swiss();
                default:
                    return new RoundRobin(Players);
            }
        }
    }
}
