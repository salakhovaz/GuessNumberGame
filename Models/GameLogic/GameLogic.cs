using GuessNumberGame.Models.GameView;
using GuessNumberGame.Models.SecretNumberGenerators.Contracts;

namespace GuessNumberGame.Models.GameLogic
{
    public class GameLogic : IGameLogic
    {
        private readonly ISecretNumberGenerator _secretNumberGenerator;
        private readonly IGameViewModel _viewModel;
        private int _secretNumber;
        private const int MinValue = 1;
        private const int MaxValue = 30;
        private const int MaxAttempts = 6;

        public GameLogic(ISecretNumberGenerator secretNumberGenerator, IGameViewModel viewModel)
        {
            _secretNumberGenerator = secretNumberGenerator;
            _viewModel = viewModel;
            StartNewGame();
        }

        public void StartNewGame()
        {
            _secretNumber = _secretNumberGenerator.Generate(MinValue, MaxValue);
            _viewModel.Attempts = 0;
            _viewModel.Message = "Угадайте число от 1 до 30.";
            _viewModel.IsGameActive = true;
        }

        public string MakeGuess(int guess)
        {
            _viewModel.Attempts++;

            if (guess == _secretNumber)
            {
                _viewModel.Message = $"Вы угадали число {_secretNumber} за {_viewModel.Attempts} попыток.";
                _viewModel.IsGameActive = false;
                _secretNumber = 0;
            }
            else if (guess < _secretNumber)
            {
                _viewModel.Message = "Загаданное число больше.";
            }
            else
            {
                _viewModel.Message = "Загаданное число меньше.";
            }

            if (_viewModel.Attempts >= MaxAttempts && guess != _secretNumber)
            {
                _viewModel.Message = $"Вы исчерпали все попытки. Загаданное число было {_secretNumber}.";
                _viewModel.IsGameActive = false;
                _secretNumber = 0;
            }

            return _viewModel.Message;
        }
    }
}
