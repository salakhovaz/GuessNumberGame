namespace GuessNumberGame.Models
{
    public class GameSettings
    {
        public int SecretNumber { get; set; }

        public int MinValue { get; set; } = 1;

        public int MaxValue { get; set; } = 30;

        public int Attempts { get; set; }

        public int MaxAttempts { get; set; } = 6;

        public string Message { get; set; } = default!;
    }
}
