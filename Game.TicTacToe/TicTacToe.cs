using System;
using System.Linq;

namespace Game.TicTacToe
{
    public enum Player
    {
        Undefined,
        P1,
        P2
    }

    public interface IGame
    {
        bool AddMove(uint x, uint y, Player player);
        Player CheckWinner();
    }

    public class TicTacToeEngine : IGame
    {
        private const int LENGTH = 3;
        private bool gameStarted = false;
        private Player[][] Moves = new Player[LENGTH][];
        private Player LastMover = Player.Undefined;

        public TicTacToeEngine()
        {
            for (int i = 0; i < LENGTH; i++)
            {
                Moves[i] = new Player[LENGTH];
            }
        }

        public bool AddMove(uint x, uint y, Player player)
        {
            if (x > 2 || y > 2 || player == Player.Undefined)
                return false;

            if (player == LastMover)
                return false;

            if (Moves[x][y] != Player.Undefined)
                return false;

            if (CheckWinner() != Player.Undefined)
                return false;

            gameStarted = true;
            Moves[x][y] = player;            
            LastMover = player;
            return true;
        }

        public Player CheckWinner()
        {
            if (!gameStarted)
                return Player.Undefined;

            // Check rows
            foreach (var row in Moves)
            {
                var first = row.First();

                if (first != Player.Undefined && row.All(x => x == first))
                    return first;
            }

            // Check columns
            for (int i = 0; i < LENGTH; i++)
            {
                var first = Moves[0][i];

                if (first != Player.Undefined && first == Moves[1][i] && first == Moves[2][i])
                    return first;
            }

            // Check crosses
            var mid = Moves[1][1];

            if (mid != Player.Undefined)
            {
                if (mid == Moves[0][0] && mid == Moves[2][2])
                    return mid;
                if (mid == Moves[2][0] && mid == Moves[0][2])
                    return mid;
            }

            // Nobody wins
            return Player.Undefined;
        }

       
    }
}
