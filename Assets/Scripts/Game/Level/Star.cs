using System;
using DG.Tweening;
using Playground.Services.Game;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Playground.Game.Level
{
    public class Star : MonoBehaviour
    {
        #region Variables

        private const int _timeDurRotate = 5;

        private LevelManager _levelManager;
        private Tween _tween;

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
            _levelManager.AddStar(this);
            _tween = transform.DOLocalRotate(new Vector3(0, 360, 360), _timeDurRotate, RotateMode.FastBeyond360)
                .SetRelative(true)
                .SetLoops(-1);
        }

        private void OnDestroy()
        {
            _tween?.Kill();
            _tween = null;
        }

        private void OnTriggerEnter(Collider other)
        {
            _levelManager.MinusStar(this);
            Destroy(gameObject);
        }

        #endregion
    }
}