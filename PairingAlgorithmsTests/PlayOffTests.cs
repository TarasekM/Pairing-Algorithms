using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using PairingAlgorithms.Systems;
using PairingAlgorithms.Models;
namespace Tests{

    public class PlayOffTests : PairingTest
    {
        private PlayOff PlayOff;
        private List<Player> Players { get; set; }

        public PlayOffTests(){
            PlayOff = new PlayOff();
        }

        [Fact]
        public void Test_First_Pairing(){
            Players = SetUpPlayers(10);
            int [] listOfIDs = new int[] { 1, 9, 2, 10, 3, 0, 4, 0, 
                                           5, 0, 6,  0, 7, 0, 8, 0 };
            List<List<int>> ExpectedPairings = SetUp_Pairings(listOfIDs);
            List<List<int>> ActualPairings = PlayOff.Pair(Players);
            Assert.Equal(ExpectedPairings, ActualPairings);
        }

        [Fact]
        public void Test_Pairing(){
            Players = SetUpPlayers(10);
            int[][] pairingsForWholeGame = new int[4][] {
                new int[] { 1, 9, 2, 10, 3, 0, 4, 0,
                            5, 0, 6,  0, 7, 0, 8, 0 },
                new int[] { 9, 2, 3, 4, 5, 6, 7, 8 },
                new int[] { 9, 4, 5, 7 },
                new int[] { 9, 5 }
            };

            for (int i = 0; i < pairingsForWholeGame.Length; i++)
            {
                Pair_Players_Test(pairingsForWholeGame[i]);
            }
        }

        private void Pair_Players_Test(int[] listOfIDs)
        {
            RemoveLosers(Players, listOfIDs);
            List<List<int>> ExpectedPairings = SetUp_Pairings(listOfIDs);
            List<List<int>> ActualPairings = PlayOff.Pair(Players);
            Assert.Equal(ExpectedPairings, ActualPairings);
        }

        private void RemoveLosers(List<Player> Players, int [] listOfIDs){
            List<Player> ToRemove = new List<Player>();
            foreach (Player player in Players){
                if (!Array.Exists(listOfIDs, ID => ID == player.ID)){
                    ToRemove.Add(player);
                }
            }

            foreach (Player loser in ToRemove){
                Players.Remove(loser);
            }
        }
    }
}