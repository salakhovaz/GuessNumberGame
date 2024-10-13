using GuessNumberGame.Models;
using GuessNumberGame.Models.SecretNumberGenerators.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GuessNumberGame.Controllers
{
    public class GuessNumberGameController : Controller
    {
        private static GameSettings _gameSettings = new GameSettings();
        private readonly ISecretNumberGenerator _secretNumberGenerator;

        public GuessNumberGameController(ISecretNumberGenerator secretNumberGenerator)
        {
            _secretNumberGenerator = secretNumberGenerator;
        }

        public IActionResult Index()
        {
            if (_gameSettings.SecretNumber == 0)
            {
                _gameSettings.SecretNumber = _secretNumberGenerator.Generate(_gameSettings.MinValue, _gameSettings.MaxValue);
                _gameSettings.Attempts = 0;
                _gameSettings.Message = "Угадайте число от 1 до 30.";
            }

            return View(_gameSettings);
        }

        [HttpPost]
        public IActionResult Guess(int guess)
        {
            _gameSettings.Attempts++;

            if (guess == _gameSettings.SecretNumber)
            {
                _gameSettings.Message = $"Вы угадали число {_gameSettings.SecretNumber} за {_gameSettings.Attempts} попыток.";
                _gameSettings.SecretNumber = 0; 
            }
            else if (guess < _gameSettings.SecretNumber)
            {
                _gameSettings.Message = "Загаданное число больше.";
            }
            else
            {
                _gameSettings.Message = "Загаданное число меньше.";
            }

            if (_gameSettings.Attempts >= _gameSettings.MaxAttempts && guess != _gameSettings.SecretNumber)
            {
                _gameSettings.Message = $"Вы исчерпали все попытки. Загаданное число было {_gameSettings.SecretNumber}.";
                _gameSettings.SecretNumber = 0;
            }

            return View("Index", _gameSettings);
        }
    }
}
