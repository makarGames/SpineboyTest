using Spine.Unity;
using UnityEngine;
using Utils;

namespace PlayerLogic
{
    [RequireComponent(typeof(SkeletonAnimation))]
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private float _stepDuration;

        [SerializeField] [SpineAnimation] private string _runAnimationName;
        [SerializeField] [SpineAnimation] private string _idleAnimationName;
        [SerializeField] [SpineAnimation] private string _aimAnimationName;

        private float _stepTime;
        private bool _isRunning = true;

        public SkeletonAnimation SkeletonAnimation => _skeletonAnimation;

        private void Start()
        {
            PlayIdle();
        }

        private void Update()
        {
            if (_isRunning)
            {
                _stepTime = Mathf.Repeat((transform.position.x - CameraHolder.ScreenBounds.x) * _stepDuration, 1);

                _skeletonAnimation.state.GetCurrent(0).TrackTime =
                    _stepTime * _skeletonAnimation.state.GetCurrent(0).AnimationEnd;
            }
        }

        public void PlayRun()
        {
            _isRunning = true;
            _skeletonAnimation.state.SetAnimation(0, _runAnimationName, true).TimeScale = 0;
        }

        public void PlayIdle()
        {
            _isRunning = false;
            _skeletonAnimation.state.SetAnimation(0, _idleAnimationName, true).TimeScale = 1;
        }

        public void StartAim()
        {
             _skeletonAnimation.state.SetAnimation(1, _aimAnimationName, false);
        }

        public void StopAim()
        {
            _skeletonAnimation.state.AddEmptyAnimation(1, 0.5f, 0);
        }

        private void OnValidate()
        {
            _skeletonAnimation = GetComponent<SkeletonAnimation>();
        }
    }
}