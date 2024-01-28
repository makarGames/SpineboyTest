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

        [SpineAnimation] public string _runAnimationName;
        [SpineAnimation] public string _idleAnimationName;

        private float _animationSpeed = 1f;

        private float _stepTime;
        private bool _isRunning = true;

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


        private void OnValidate()
        {
            _skeletonAnimation = GetComponent<SkeletonAnimation>();
        }
    }
}