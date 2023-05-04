using System;
using System.Linq;
using Game.TicTacToe;

namespace Game.Host.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new TicTacToeEngine();
            Player playerTurn = Player.P1;

            while (true)
            {
                Console.WriteLine($"Waiting input for {playerTurn}: ");
                var pMove = Console.ReadLine();

                if (pMove.Length != 3 || pMove[1] != ',' || !int.TryParse(pMove.Remove(1, 1), out int t))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                var coordinateStrings = pMove.Split(',');

                var coordinates = coordinateStrings.Select(x => Convert.ToUInt32(x)).ToList();

                if (!engine.AddMove(coordinates[0], coordinates[1], playerTurn))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                playerTurn = Player.P1 == playerTurn ? Player.P2 : Player.P1;
                var winner = engine.CheckWinner();

                if (winner != Player.Undefined)
                {
                    Console.WriteLine("Game end. Winner: " + winner);
                    break;
                }
            }

            Console.ReadLine();
        }
    }
}
