using System;
using DG.Tweening;
using Playground.Audio;
using UnityEngine;
using Zenject;

namespace Playground.Game.Level
{
    public class DoorButton : MonoBehaviour
    {
        #region Variables

        [Header("Reference")]
        [SerializeField] private Door _door;

        [Header("Animation")]
        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private Vector3 _endPosition;
        [SerializeField] private float _animationDuration;
        [SerializeField] private float _unclickDelay;

        private AudioService _audioService;
        private bool _isClicked;

        private bool _isInTrigger;

        private Tween _tween;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(AudioService audioService)
        {
            _audioService = audioService;
        }

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter(Collider other)
        {
            _isInTrigger = true;
            PlayClickAnimation();
        }

        private void OnTriggerExit(Collider other)
        {
            TryPlayUnclickAnimation();
            _isInTrigger = false;
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
                        _isClicked = true;
                        _door.Open();
                        PlayUnclickAnimation();
                        _audioService.PlaySound(SoundType.DoorButton);
                    }
                );
        }

        private void PlayUnclickAnimation()
        {
            _isClicked = false;
            _tween?.Kill();
            _tween = transform
                .DOMove(_startPosition, _animationDuration)
                .SetUpdate(UpdateType.Fixed)
                .SetDelay(_unclickDelay)
                .OnComplete(() => _door.Close());
        }

        private void TryPlayUnclickAnimation()
        {
            Debug.Log($"TryPlayUnclickAnimation _isClicked {_isClicked}  _isInTrigger {_isInTrigger}");
            if (_isClicked && _isInTrigger)
            {
                PlayUnclickAnimation();
            }
        }

        #endregion
    }
}