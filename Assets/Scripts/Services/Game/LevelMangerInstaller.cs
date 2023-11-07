using Playground.Services.Game;
using Zenject;

namespace Playground.Infrastructure.Installers
{
    public class LevelMangerInstaller : Installer<LevelMangerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<LevelManager>().AsSingle();
        }

    }
}