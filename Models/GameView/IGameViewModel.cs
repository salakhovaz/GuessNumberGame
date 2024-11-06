namespace GuessNumberGame.Models.GameView
{
    public interface IGameViewModel
    {
        string Message { get; set; }
        int Attempts { get; set; }
        bool IsGameActive { get; set; }
    }
}
