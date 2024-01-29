using Infrastructure;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace PlayerLogic
{
    [RequireComponent(typeof(Player))]
    public class PlayerAimController : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private float _closeAimRotationOffset = -10f;
        [SerializeField] private float _farAimRotationOffset = -20f;

        private Bone _crosshairBone;
        private bool _isAim;
        private bool _isFarAim;

        private PlayerData PlayerData => _player.PlayerData;
        private SkeletonAnimation SkeletonAnimation => PlayerData.PlayerAnimator.SkeletonAnimation;
        private float CurrentRotationOffset => _isFarAim ? _farAimRotationOffset : _closeAimRotationOffset;

        private void Awake()
        {
            PlayerInput.OnClickDownEvent += StartAim;
            PlayerInput.OnClickUpEvent += StopAim;
        }

        private void Start()
        {
            _crosshairBone = SkeletonAnimation.Skeleton.FindBone(PlayerData.CrosshairBoneName);

            SkeletonAnimation.UpdateLocal += UpdateLocal;
        }
        
        private void Update()
        {
            if (_isAim)
            {
                bool isFarFromPlayer = PlayerInput.CursorWorldPosition.y - PlayerData.PlayerTransform.position.y >
                                       PlayerData.Height * 2;

                if (isFarFromPlayer && !_isFarAim)
                {
                    _isFarAim = true;
                    PlayerData.PlayerAnimator.StartAim();
                }
                else if (!isFarFromPlayer && _isFarAim)
                {
                    _isFarAim = false;
                    PlayerData.PlayerAnimator.StopAim();
                }
            }
        }

        private void OnDestroy()
        {
            PlayerInput.OnClickDownEvent -= StartAim;
            PlayerInput.OnClickUpEvent -= StopAim;
            
            SkeletonAnimation.UpdateLocal -= UpdateLocal;
        }

        private void UpdateLocal(ISkeletonAnimation _)
        {
            if (_isAim)
            {
                var crosshairPosition = _crosshairBone.GetWorldPosition(PlayerData.PlayerTransform);

                var directionToCursor = (PlayerInput.CursorWorldPosition - crosshairPosition).normalized;

                var targetAngle = Mathf.Atan2(directionToCursor.y, directionToCursor.x) * Mathf.Rad2Deg;

                _crosshairBone.Rotation = targetAngle + CurrentRotationOffset;
            }
        }

        private void StartAim()
        {
            _isAim = true;
        }

        private void StopAim()
        {
            _isAim = false;
            _isFarAim = false;

            PlayerData.PlayerAnimator.StopAim();
        }

        private void OnValidate()
        {
            _player = GetComponent<Player>();
        }
    }
}