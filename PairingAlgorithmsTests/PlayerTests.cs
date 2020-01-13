using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using PairingAlgorithms.Systems;
using PairingAlgorithms.Models;

namespace Tests{
    public class PlayerTests : IClassFixture<PlayerFixture>
    {
        PlayerFixture pf1;
        PlayerFixture pf2;

        public PlayerTests(PlayerFixture pf1, PlayerFixture pf2){
            this.pf1 = pf1;
            this.pf2 = pf2;
            Dispose();
        }

        [Fact]
        public void Test_Players_Can_Not_Play_Both_White(){
            pf1.player.GamesAsWhite = 2;
            pf2.player.GamesAsWhite = 2;
            Assert.False(pf1.player.CanPlay(pf2.player));
            Assert.False(pf2.player.CanPlay(pf1.player));
            Dispose();
        }

        [Fact]
        public void Test_Players_Can_Not_Play_Both_Black(){
            pf1.player.GamesAsBlack = 2;
            pf2.player.GamesAsBlack = 2;
            Assert.False(pf1.player.CanPlay(pf2.player));
            Assert.False(pf2.player.CanPlay(pf1.player));
            Dispose();
        }

        [Fact]
        public void Test_Players_Can_Play_Both_Colors_Case_1(){
            Assert.True(pf1.player.CanPlay(pf2.player));
            Assert.True(pf2.player.CanPlay(pf1.player));
            Dispose();
        }

        [Fact]
        public void Test_Players_Can_Play_Both_Colors_Case_2(){
            pf1.player.GamesAsWhite = 1;
            pf2.player.GamesAsWhite = 1;
            Assert.True(pf1.player.CanPlay(pf2.player));
            Assert.True(pf2.player.CanPlay(pf1.player));
            Dispose();
        }

        [Fact]
        public void Test_Players_Can_Play_Both_Colors_Case_3(){
            pf1.player.GamesAsBlack = 1;
            pf2.player.GamesAsBlack = 1;
            Assert.True(pf1.player.CanPlay(pf2.player));
            Assert.True(pf2.player.CanPlay(pf1.player));
            Dispose();    
        }

        [Fact]
        public void Test_Players_Can_Play_Both_Colors_Case_4(){
            pf1.player.GamesAsWhite = 1;
            pf2.player.GamesAsBlack = 1;
            Assert.True(pf1.player.CanPlay(pf2.player));
            Assert.True(pf2.player.CanPlay(pf1.player));
            Dispose();    
        }
        
        [Fact]
        public void Test_Players_One_Can_Not_Play_White(){
            pf1.player.GamesAsWhite = 2;
            pf2.player.GamesAsWhite = 1;
            pf2.player.GamesAsBlack = 1;
            Assert.True(pf1.player.CanPlay(pf2.player));
            Assert.True(pf2.player.CanPlay(pf1.player));
            Dispose();
        }

        [Fact]
        public void Test_Players_One_Can_Not_Play_White_Black(){
            pf1.player.GamesAsBlack = 2;
            pf2.player.GamesAsWhite = 1;
            pf2.player.GamesAsBlack = 1;
            Assert.True(pf1.player.CanPlay(pf2.player));
            Assert.True(pf2.player.CanPlay(pf1.player));
        }

        private void Dispose(){
            pf1.Dispose();
            pf2.Dispose();
        }
    }

    
    public class PlayerFixture : IDisposable
    {
        public Player player { get ; set; }
        public PlayerFixture(){
            player = Player.GetByePlayer();
        }

        public void Dispose(){
            player = Player.GetByePlayer();
        }
    }
}