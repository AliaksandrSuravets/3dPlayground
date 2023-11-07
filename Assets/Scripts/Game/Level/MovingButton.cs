using DG.Tweening;
using UnityEngine;

namespace Playground.Game.Level
{
    public class MovingButton : MonoBehaviour
    {
        #region Variables

        [Header("Reference")]
        [SerializeField] private MovingPlatform[] _movingPlatforms;

        [Header("Animation")]
        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private Vector3 _endPosition;
        [SerializeField] private float _animationDuration;

        private Tween _tween;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter(Collider other)
        {
            PlayClickAnimation();
        }

        #endregion

        #region Private methods

        private void PlayClickAnimation()
        {
            _tween?.Kill();
            _tween = transform
                .DOMove(_endPosition, _animationDuration)
                .SetUpdate(UpdateType.Fixed)
                .OnComplete(() =>
                    {
                        foreach (MovingPlatform movingPlatform in _movingPlatforms)
                        {
                            movingPlatform.Move();
                        }
                    }
                );
        }

        #endregion
    }
}