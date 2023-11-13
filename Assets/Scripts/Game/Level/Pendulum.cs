using DG.Tweening;
using UnityEngine;

namespace Playground.Game.Level
{
    public class Pendulum : MonoBehaviour
    {
        #region Variables

        private const int ANGLE_SLOPE = 89;

        private const int TIME_DUR_ROTATE = 2;
        [SerializeField] private AnimationCurve _movementEase;

        private Tween _tween;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            Quaternion transformRotation = transform.localRotation;
            transformRotation.x = ANGLE_SLOPE;
            transform.Rotate(transformRotation.x, 0, 0);
            Sequence sequence = DOTween.Sequence();
            //sequence.SetEase(_movementEase);
            sequence.Append(transform.DOLocalRotate(new Vector3(-ANGLE_SLOPE, 0, 0), TIME_DUR_ROTATE));
            sequence.Append(transform.DOLocalRotate(new Vector3(ANGLE_SLOPE, 0, 0), TIME_DUR_ROTATE));
            sequence.SetLoops(-1);
            sequence.SetUpdate(UpdateType.Fixed);
            _tween = sequence;
        }

        private void OnDestroy()
        {
            _tween?.Kill();
            _tween = null;
        }

        #endregion
    }
}