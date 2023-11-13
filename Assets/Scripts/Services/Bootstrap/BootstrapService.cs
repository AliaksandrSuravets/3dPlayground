using Cysharp.Threading.Tasks;
using Playground.Audio;
using Playground.Services.Game;

namespace Playground.Services.Bootstrap
{
    public class BootstrapService
    {
        #region Variables

        private readonly GameService _gameService;
        private readonly AudioService _audioService;
        #endregion

        #region Setup/Teardown

        public BootstrapService(GameService gameService, AudioService audioService)
        {
            _gameService = gameService;
            _audioService = audioService;
        }

        #endregion

        #region Public methods

        public void Bootstrap()
        {
            BootstrapAsync().Forget();
        }

        #endregion

        #region Private methods

        private async UniTask BootstrapAsync()
        {
            _audioService.Init();
            // await UniTask.Delay(2 * 1000);
            _gameService.TransitionToGame();
        }

        #endregion
    }
}