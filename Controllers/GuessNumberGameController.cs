using GuessNumberGame.Models.GameLogic;
using GuessNumberGame.Models.GameView;
using Microsoft.AspNetCore.Mvc;

namespace GuessNumberGame.Controllers
{
    public class GuessNumberGameController : Controller
    {
        private readonly IGameLogic _gameLogic;
        private readonly IGameViewModel _viewModel;

        public GuessNumberGameController(IGameLogic gameLogic, IGameViewModel viewModel)
        {
            _gameLogic = gameLogic;
            _viewModel = viewModel;
        }

        public IActionResult Index()
        {
            if (!_viewModel.IsGameActive)
            {
                _gameLogic.StartNewGame();
            }

            return View(_viewModel);
        }

        [HttpPost]
        public IActionResult Guess(int guess)
        {
            _gameLogic.MakeGuess(guess);
            return View("Index", _viewModel);
        }
    }
}
