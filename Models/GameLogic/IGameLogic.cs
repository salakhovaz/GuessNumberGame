namespace GuessNumberGame.Models.GameLogic
{
    public interface IGameLogic
    {
        void StartNewGame();
        string MakeGuess(int guess);
    }
}
