using System;

namespace Game
{
    public class Player
    {
        public long Id { get; set; }
        public string Nick { get; set; }
    }

    public interface IBoard
    { }

    public interface IResult
    {
        string Message { get; }
        int ResponseCode { get; }
    }

    public interface IMove
    {
        long PlayerId { get; }
    }
    public interface IGameEngine
    {
        IResult AddPlayer(long playerId);
        IResult AddMove(IMove move);
        long CheckWinner();
        long CurrentPlayerId { get; }
        IBoard GetBoard();
    }

    #region ChessEngine
    public class ChessPlayer : Player
    {

    }
    #endregion
}
