using System;
using System.Collections.Generic;
using PairingAlgorithms.Systems;
using PairingAlgorithms.Models;
namespace Tests{

    public class PairingTest
    {
        protected List<Player> SetUpPlayers(int n)
        {
            List<Player> Players = new List<Player>();

            for (int i = 1; i <= n; i++)
            {
                Players.Add(new Player(i, "Zawodnik nr " + i));
            }

            return Players;
        }
         
        protected List<List<int>> SetUp_Pairings(int[] listOfPlayerIDs)
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