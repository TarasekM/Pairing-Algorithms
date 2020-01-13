using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using PairingAlgorithms.Systems;
using PairingAlgorithms.Models;
namespace Tests{

    public class SwissTests : PairingTest
    {
        private Pairing swiss;
        private List<Player> Players { get; set; }

        public SwissTests(){
            swiss = new Swiss();
            Players = SetUpPlayers(30);
        }

        [Fact]
        public void Test_Swiss(){
            List<List<int>> Pairings;
            for(int i = 1; i <= 9; i++){
                Pairings = swiss.Pair(Players);
                PairRound(Pairings, Players);
            }
            // while (true){
            //     // 1
            //     List<List<int>> Pairings = swiss.Pair(Players);
            //     PairRound(Pairings, Players);
            //     Players[1 - 1].Score++;
            //     Players[3 - 1].Score++;
            //     Players[5 - 1].Score++;
            //     Players[7 - 1].Score++;

            //     // 2
            //     Pairings = swiss.Pair(Players);
            //     PairRound(Pairings, Players);
            //     Players[6 - 1].Score++;
            //     Players[5 - 1].Score++;
            //     Players[2 - 1].Score++;
            //     Players[1 - 1].Score++;

            //     // 3
            //     Pairings = swiss.Pair(Players);
            //     PairRound(Pairings, Players);
            //     Players[6 - 1].Score++;
            //     Players[2 - 1].Score++;
            //     Players[5 - 1].Score++;
            //     Players[1 - 1].Score++;

            //     // 4
            //     Pairings = swiss.Pair(Players);
            //     PairRound(Pairings, Players);
            //     Players[4 - 1].Score++;
            //     Players[3 - 1].Score++;
            //     Players[2 - 1].Score++;
            //     Players[1 - 1].Score++;

            //     // 5
            //     Pairings = swiss.Pair(Players);
            //     PairRound(Pairings, Players);
            //     Players[4 - 1].Score++;
            //     Players[3 - 1].Score++;
            //     Players[2 - 1].Score++;
            //     Players[1 - 1].Score++;

            //     // 6
            //     Pairings = swiss.Pair(Players);
            //     PairRound(Pairings, Players);
            //     Players[4 - 1].Score++;
            //     Players[3 - 1].Score++;
            //     Players[2 - 1].Score++;
            //     Players[1 - 1].Score++;
               
            //     // 7
            //     Pairings = swiss.Pair(Players);
            //     PairRound(Pairings, Players);
            //     Players[4 - 1].Score++;
            //     Players[3 - 1].Score++;
            //     Players[2 - 1].Score++;
            //     Players[1 - 1].Score++;

            // }
        }

        private void PairRound(List<List<int>> Pairings, List<Player> players){
            for(int i = 0; i < Pairings.Count; i++){
                List<int> pair = Pairings[i];
                Player white = players.Find(x => x.ID == pair[0]);
                Player black = players.Find(x => x.ID == pair[1]);
                white.Pair(black);
            }
            foreach(Player player in players){
                player.HaveOpponent = false;
            }
        }
    }
}