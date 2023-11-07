using System;
using System.Collections.Generic;
using Playground.Game.Level;
using UnityEngine;

namespace Playground.Services.Game
{
    public class LevelManager
    {
        #region Variables

        private readonly List<Star> _stars = new List<Star>();

        #endregion

        #region Events

        public event Action OnAllStarsDestroyed;

        #endregion

        #region Public methods

        public void AddStar(Star star)
        {
            _stars.Add(star);
            Debug.Log($"List {_stars.Count}");
        }

        public void MinusStar(Star star)
        {
            _stars.Remove(star);
            Debug.Log($"List {_stars.Count}");
            CheckAllStarDestroy();
        }

        #endregion

        #region Private methods

        private void CheckAllStarDestroy()
        {
            if (_stars.Count == 0)
            {
                Debug.Log("OnAllStarsDestroyed");
                OnAllStarsDestroyed?.Invoke();
            }
        }

        #endregion
    }
}