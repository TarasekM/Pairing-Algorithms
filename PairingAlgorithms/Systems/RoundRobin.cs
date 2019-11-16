using System;
using System.Collections.Generic;
using PairingAlgorithms.Models;

namespace PairingAlgorithms.Systems
{
    public class RoundRobin : Pairing
    {
        private List<Player> FirstHalf { get; set; }
        private List<Player> SecondHalf { get; set; }

        public RoundRobin()
        {
            CurrentRound = 1;
        }

        private void SetUpTables(List<Player> Players)
        {
            // Add BYE player if there's odd number of players. Keep in mind Bye player always have ID of 0
            int m = (int)(Math.Ceiling((decimal)Players.Count / 2));
            int r = Players.Count - 1;
            FirstHalf = Players.GetRange(0, m);
            SecondHalf = Players.GetRange(m, r - m + 1);
            SecondHalf.Reverse();
            if (SecondHalf.Count < FirstHalf.Count)
            {
                SecondHalf.Add(new Player(0, "BYE"));
            }
        }

        public override List<List<Player>> Pair(List<Player> Players)
        {
            // Split tables into 2 if it's round 1
            if (CurrentRound == 1)
            {
                SetUpTables(Players);
            }
            // Return if max rounds has been played
            if (CurrentRound >= Players.Count - 1)
            {
                return GetPairings();
            }
            List<List<Player>> Pairings = GetPairings();
            Rotate();
            CurrentRound++;
            return Pairings;
        }

        public void Rotate()
        {
            Player lastFromFirstHalf = FirstHalf[FirstHalf.Count - 1];
            Player firstFromSecondHalf = SecondHalf[0];

            for(int i = FirstHalf.Count - 1; i > 1; i--)
            {
                FirstHalf[i] = FirstHalf[i - 1];
            }
            FirstHalf[1] = firstFromSecondHalf;
            SecondHalf.Remove(firstFromSecondHalf);
            SecondHalf.Add(lastFromFirstHalf);
        }

        public List<List<Player>> GetPairings()
        {
            List<List<Player>> Pairings = new List<List<Player>>();
            for (int i = 0; i < FirstHalf.Count; i++)
            {
                List<Player> Pair = new List<Player>();
                Player white = FirstHalf[i];
                Player black = SecondHalf[i];
                Pair.Add(white);
                Pair.Add(black);
                Pairings.Add(Pair);
                white.Pair(black);
            }

            if (CurrentRound % 2 == 0)
            {
                Pairings[0].Reverse();
                Pairings[0][0].Pair(Pairings[0][1]);
            }
            return Pairings;
        }
    }
}
