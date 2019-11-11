using System;
using System.Collections.Generic;
using System.Text;
using PlatformForChessMatchmaking.Models;

namespace PlatformForChessMatchmaking.Algorithms
{
    public class RoundRobin : Pairing
    {
        private List<Player> FirstHalf { get; set; }
        private List<Player> SecondHalf { get; set; }

        public RoundRobin(List<Player> Players) : base(Players)
        {
            SetUpTables();
            CurrentRound = 0;
        }

        private void SetUpTables()
        {
            int m = (int)(Math.Ceiling((decimal)Players.Count / 2));
            int r = Players.Count - 1;
            FirstHalf = Players.GetRange(0, m);
            SecondHalf = Players.GetRange(m, r - m + 1);
            SecondHalf.Reverse();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }

        public override List<Player> Pair()
        {
            if (CurrentRound++ >= Players.Count - 1)
            {
                return Players;
            }
            PrintMatchings(); //TODO remove it
            Rotate();
            return Players;
        }

        public void PrintMatchings()
        {
            for (int i = 0; i < FirstHalf.Count; i++)
            {
                Console.WriteLine(FirstHalf[i] + " vs " + SecondHalf[i]);
            }
        }

        public void Rotate()
        {
            Player lastFromFirstHalf = FirstHalf[FirstHalf.Count - 1];
            Player firstFromSecondHalf = SecondHalf[0];

            for(int i = 1; i < FirstHalf.Count - 1; i++)
            {
                FirstHalf[i + 1] = FirstHalf[i];
            }
            FirstHalf[1] = firstFromSecondHalf;
            SecondHalf.Remove(firstFromSecondHalf);
            SecondHalf.Add(lastFromFirstHalf);

        }
    }
}
