namespace GuessNumberGame.Models.GameView
{
    public class GameViewModel : IGameViewModel
    {
        public string Message { get; set; } = "Угадайте число от 1 до 30.";
        public int Attempts { get; set; } = 0;
        public bool IsGameActive { get; set; } = true;
    }
}
