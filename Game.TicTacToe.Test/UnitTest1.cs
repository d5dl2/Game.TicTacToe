using System;
using Xunit;

namespace Game.TicTacToe.Test
{
    public class TicTacToeTest
    {
        [Theory]
        [InlineData(3, 2, Player.P1)]
        [InlineData(0, 3, Player.P1)]
        [InlineData(0, 0, Player.Undefined)]
        public void AddMove_ReturnsFalse_InvalidInput(uint x, uint y, Player player)
        {
            TicTacToeEngine ticTacToe = new();

            Assert.False(ticTacToe.AddMove(x, y, player));
        }

        [Fact]
        public void AddMove_ReturnsFalse_SamePlayerMove()
        {
            TicTacToeEngine ticTacToe = new();

            Assert.True(ticTacToe.AddMove(0, 0, Player.P1));
            Assert.False(ticTacToe.AddMove(0, 1, Player.P1));
        }

        [Fact]
        public void AddMove_ReturnsFalse_SameCoordinateMove()
        {
            TicTacToeEngine ticTacToe = new();

            Assert.True(ticTacToe.AddMove(0, 0, Player.P1));
            Assert.False(ticTacToe.AddMove(0, 0, Player.P2));
        }

        [Fact]
        public void AddMove_ReturnsFalse_AfterGameEnd()
        {
            TicTacToeEngine ticTacToe = new TicTacToeEngine();

            ticTacToe.AddMove(0, 0, Player.P2);
            ticTacToe.AddMove(0, 1, Player.P1);
            ticTacToe.AddMove(1, 0, Player.P2);
            ticTacToe.AddMove(0, 2, Player.P1);
            ticTacToe.AddMove(2, 0, Player.P2);

            Assert.False(ticTacToe.AddMove(2, 2, Player.P1));
        }

        [Fact]
        public void CheckWinner_ReturnsUndefined_BeforeGameStarts()
        {
            TicTacToeEngine ticTacToe = new TicTacToeEngine();

            Assert.Equal(Player.Undefined, ticTacToe.CheckWinner());
        }

        [Fact]
        public void CheckWinner_ReturnsValidWinner_AfterSomeOneWins()
        {
            TicTacToeEngine ticTacToe = new TicTacToeEngine();

            ticTacToe.AddMove(0, 0, Player.P2);
            Assert.Equal(Player.Undefined, ticTacToe.CheckWinner());
            ticTacToe.AddMove(0, 1, Player.P1);
            Assert.Equal(Player.Undefined, ticTacToe.CheckWinner());
            ticTacToe.AddMove(1, 0, Player.P2);
            Assert.Equal(Player.Undefined, ticTacToe.CheckWinner());
            ticTacToe.AddMove(0, 2, Player.P1);
            Assert.Equal(Player.Undefined, ticTacToe.CheckWinner());
            ticTacToe.AddMove(2, 0, Player.P2);
            Assert.Equal(Player.P2, ticTacToe.CheckWinner());
        }
    }
}
