using Cysharp.Threading.Tasks;
using Playground.Services.Scene;
using SPL.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Playground.Game.Level
{
    public class DeadZone : MonoBehaviour
    {
        #region Variables

        private SceneLoader _sceneLoader;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter(Collider other)
        {
            _sceneLoader.LoadSceneAsync(SceneManager.GetActiveScene().name).Forget();;
        }

        #endregion
    }
}