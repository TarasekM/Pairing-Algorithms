using NUnit.Framework;
using System.Collections.Generic;
using PairingAlgorithms.Models;
using PairingAlgorithms.Systems;
namespace Tests
{
    public class RoundRobinTests
    {
        private RoundRobin RoundRobin = new RoundRobin();
        private Player ByePlayer = new Player(0, "BYE");
        private List<Player> Players { get; set; }

        [SetUp]
        public void Setup()
        {
            RoundRobin = new RoundRobin();
        }

        [Test]
        public void Full_Tournament_Odd_Players_Pair_Test()
        {
            Players = SetUpPlayers(7);
            int[][] pairingsForWholeGame = new int[7][] {
                new int[] { 1, 7, 2, 6, 3, 5, 4, 0 },
                new int[] { 6, 1, 7, 5, 2, 0, 3, 4 },
                new int[] { 1, 5, 6, 0, 7, 4, 2, 3 },
                new int[] { 0, 1, 5, 4, 6, 3, 7, 2 },
                new int[] { 1, 4, 0, 3, 5, 2, 6, 7 },
                new int[] { 3, 1, 4, 2, 0, 7, 5, 6 },
                new int[] { 3, 1, 4, 2, 0, 7, 5, 6 }
            };

            for (int i = 0; i < pairingsForWholeGame.Length; i++)
            {
                Pair_Players_Test(pairingsForWholeGame[i]);
            }
        }

        [Test]
        public void Full_Tournament_Even_Players_Pair_Test()
        {
            Players = SetUpPlayers(8);
            int[][] pairingsForWholeGame = new int[8][] {
                new int[] { 1, 8, 2, 7, 3, 6, 4, 5 },
                new int[] { 7, 1, 8, 6, 2, 5, 3, 4 },
                new int[] { 1, 6, 7, 5, 8, 4, 2, 3 },
                new int[] { 5, 1, 6, 4, 7, 3, 8, 2 },
                new int[] { 1, 4, 5, 3, 6, 2, 7, 8 },
                new int[] { 3, 1, 4, 2, 5, 8, 6, 7 },
                new int[] { 1, 2, 3, 8, 4, 7, 5, 6 },
                new int[] { 1, 2, 3, 8, 4, 7, 5, 6 }
            };

            for (int i = 0; i < pairingsForWholeGame.Length; i++)
            {
                Pair_Players_Test(pairingsForWholeGame[i]);
            }
        }

        private void Pair_Players_Test(int [] listOfIDs)
        {
            List<List<Player>> ExpectedPairings = SetUp_Pairings(listOfIDs);
            List<List<Player>> ActualPairings = RoundRobin.Pair(Players);
            Assert.AreEqual(ExpectedPairings, ActualPairings);
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

        private List<List<Player>> SetUp_Pairings(int [] listOfPlayerIDs)
        {

            List<List<Player>> ExpectedPairings = new List<List<Player>>();
            for(int i = 0; i < listOfPlayerIDs.Length; i+=2)
            {
                Player First;
                Player Second;
                int firstID = listOfPlayerIDs[i];
                int secondID = listOfPlayerIDs[i + 1];

                if (firstID == 0)
                {
                    First = ByePlayer;
                }
                else
                {
                    First = Players[firstID - 1];
                }

                if (secondID == 0)
                {
                    Second = ByePlayer;
                }
                else
                {
                    Second = Players[secondID - 1];
                }

                List<Player> Pair = new List<Player>
                {
                    First,
                    Second
                };
                ExpectedPairings.Add(Pair);
            }
            
            return ExpectedPairings;
        }
    }
}