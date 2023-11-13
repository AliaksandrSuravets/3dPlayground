using Zenject;

namespace Playground.Services.Game
{
    public class LevelMangerInstaller : Installer<LevelMangerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<LevelManager>().AsSingle();
        }

    }
}