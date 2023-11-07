using System;
using Playground.Services.Game;
using UnityEngine;
using Zenject;

namespace Playground.Game.Level
{
    public class PortalActivator : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Portal _portal;

        private LevelManager _levelManager;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(LevelManager levelManager)
        {
            _levelManager = levelManager;
        }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _levelManager.OnAllStarsDestroyed += OnAllStarsDestroyed;
        }

        private void OnDestroy()
        {
            _levelManager.OnAllStarsDestroyed -= OnAllStarsDestroyed;
        }

        #endregion

        #region Private methods

        private void OnAllStarsDestroyed()
        {
            _portal.gameObject.SetActive(true);
        }

        #endregion
    }
}