using System;
using System.Collections.Generic;
using PairingAlgorithms.Models;

namespace PairingAlgorithms.Systems
{
    public class RoundRobin : Pairing
    {
        private List<int> FirstHalf { get; set; }
        private List<int> SecondHalf { get; set; }

        public RoundRobin()
        {
            FirstHalf = new List<int>();
            SecondHalf = new List<int>();
            CurrentRound = 1;
        }

        public override List<List<int>> Pair(List<Player> Players)
        {
            // Split tables into 2 if it's round 1
            if (CurrentRound == 1)
            {
                SetUpTables(Players);
            }
            // Return if max rounds has been played
            if (CurrentRound >= Players.Count - 1)
            {
                return GetPairings(Players);
            }
            List<List<int>> Pairings = GetPairings(Players);
            Rotate();
            CurrentRound++;
            return Pairings;
        }

        private void SetUpTables(List<Player> Players)
        {
            // Add BYE player if there's odd number of players. Keep in mind Bye player always have ID of 0
            int m = (int)(Math.Ceiling((decimal)Players.Count / 2));
            int r = Players.Count;
            int index = 0;
            for (; index < m; index++)
            {
                FirstHalf.Add(Players[index].ID);
            }

            for (; index < r; index++)
            {
                SecondHalf.Add(Players[index].ID);
            }

            // skip first round if there are odd number of players
            if (Players.Contains(Player.GetByePlayer()))
            {
                Rotate();
                CurrentRound++;
            }
        }

        private void Rotate()
        {
            int lastFromFirstHalf = FirstHalf[FirstHalf.Count - 1];
            int firstFromSecondHalf = SecondHalf[0];

            for(int i = FirstHalf.Count - 1; i > 1; i--)
            {
                FirstHalf[i] = FirstHalf[i - 1];
            }
            FirstHalf[1] = firstFromSecondHalf;
            SecondHalf.Remove(firstFromSecondHalf);
            SecondHalf.Add(lastFromFirstHalf);
        }

        private List<List<int>> GetPairings(List<Player> Players)
        {
            List<List<int>> Pairings = new List<List<int>>();

            for (int i = 0; i < FirstHalf.Count; i++)
            {
                List<int> Pair = GetPair(i);
                Pairings.Add(Pair);
            }
            return Pairings;
        }

        private List<int> GetPair(int n)
        {
            int white;
            int black;
            if (n % 2 == 1 || (CurrentRound % 2 == 0 && n == 0))
            {
                white = SecondHalf[n];
                black = FirstHalf[n];

            }else
            {
                white = FirstHalf[n];
                black = SecondHalf[n];
            }

            List<int> Pair = new List<int>()
            {
                white,
                black
            };

            return Pair;
        }
        
    }
}
