using DG.Tweening;
using UnityEngine;

namespace Playground.Game.Level
{
    public class Door : MonoBehaviour
    {
        #region Variables

        [Header("Animation")]
        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private Vector3 _endPosition;
        [SerializeField] private float _animationDuration;

        private Tween _tween;

        #endregion

        #region Public methods

        public void Close()
        {
            _tween?.Kill();

            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOShakePosition(_animationDuration));
            sequence.Append(transform.DOMove(_startPosition, _animationDuration));
            sequence.SetUpdate(UpdateType.Fixed);
            _tween = sequence;
        }

        public void Open()
        {
            _tween?.Kill();
            _tween = transform
                .DOMove(_endPosition, _animationDuration)
                .SetUpdate(UpdateType.Fixed);
        }

        #endregion
    }
}