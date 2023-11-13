using Playground.Services.Game;
using Playground.Services.Input;
using Zenject;

namespace Playground.Infrastructure.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        #region Public methods

        public override void InstallBindings()
        {
            InputServiceInstaller.Install(Container);
            LevelMangerInstaller.Install(Container);
        }

        #endregion
    }
}