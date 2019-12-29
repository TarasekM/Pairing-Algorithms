using System;
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
            Players = SetUpPlayers(10);
        }

        [Fact]
        public void Test_First_Pairings(){
            int [] listOfIDs = new int[] { 1, 9, 2, 10, 3, 0, 4, 0, 
                                           5, 0, 6,  0, 7, 0, 8, 0 };
            List<List<int>> ExpectedPairings = SetUp_Pairings(listOfIDs);
            List<List<int>> ActualPairings = PlayOff.Pair(Players);
            Assert.Equal(ExpectedPairings, ActualPairings);
        }
    }
}