using Xunit;
using System.Collections.Generic;
using PairingAlgorithms.Models;
using PairingAlgorithms.Systems;
namespace Tests
{
    public class RoundRobinTests
    {
        private RoundRobin RoundRobin = new RoundRobin();
        private List<Player> Players { get; set; }

        [Fact]
        public void Full_Tournament_Odd_Players_Pair_Test()
        {
            Players = SetUpPlayers(7);
            Players.Add(Player.GetByePlayer());
            int[][] pairingsForWholeGame = new int[7][] {
                new int[] { 6, 1, 7, 5, 2, 0, 4, 3 },
                new int[] { 1, 7, 0, 6, 5, 4, 3, 2 },
                new int[] { 0, 1, 4, 7, 6, 3, 2, 5 },
                new int[] { 1, 4, 3, 0, 7, 2, 5, 6 },
                new int[] { 3, 1, 2, 4, 0, 5, 6, 7 },
                new int[] { 1, 2, 5, 3, 4, 6, 7, 0 },
                new int[] { 1, 2, 5, 3, 4, 6, 7, 0 }
            };

            for (int i = 0; i < pairingsForWholeGame.Length; i++)
            {
                Pair_Players_Test(pairingsForWholeGame[i]);
            }
        }

        [Fact]
        public void Full_Tournament_Even_Players_Pair_Test()
        {
            Players = SetUpPlayers(8);
            int[][] pairingsForWholeGame = new int[8][] {
                new int[] { 1, 5, 6, 2, 3, 7, 8, 4 },
                new int[] { 6, 1, 7, 5, 2, 8, 4, 3 },
                new int[] { 1, 7, 8, 6, 5, 4, 3, 2 },
                new int[] { 8, 1, 4, 7, 6, 3, 2, 5 },
                new int[] { 1, 4, 3, 8, 7, 2, 5, 6 },
                new int[] { 3, 1, 2, 4, 8, 5, 6, 7 },
                new int[] { 1, 2, 5, 3, 4, 6, 7, 8 },
                new int[] { 1, 2, 5, 3, 4, 6, 7, 8 }
            };

            for (int i = 0; i < pairingsForWholeGame.Length; i++)
            {
                Pair_Players_Test(pairingsForWholeGame[i]);
            }
        }


        private void Pair_Players_Test(int[] listOfIDs)
        {
            List<List<int>> ExpectedPairings = SetUp_Pairings(listOfIDs);
            List<List<int>> ActualPairings = RoundRobin.Pair(Players);
            Assert.Equal(ExpectedPairings, ActualPairings);
        }

        private List<Player> SetUpPlayers(int n)
        {
            List<Player> Players = new List<Player>();

            for (int i = 1; i <= n; i++)
            {
                Players.Add(new Player(i, "Zawodnik nr " + i));
            }

            return Players;
        }

        private List<List<int>> SetUp_Pairings(int[] listOfPlayerIDs)
        {

            List<List<int>> ExpectedPairings = new List<List<int>>();
            for (int i = 0; i < listOfPlayerIDs.Length; i += 2)
            {
                int firstID = listOfPlayerIDs[i];
                int secondID = listOfPlayerIDs[i + 1];

                List<int> Pair = new List<int>
                {
                    firstID,
                    secondID
                };
                ExpectedPairings.Add(Pair);
            }

            return ExpectedPairings;
        }
    }
}