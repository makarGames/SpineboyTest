using Infrastructure;
using PlayerLogic;
using UnityEngine;
using Utils;

namespace SateMachineLogic.PlayerStates
{
    public class MovingPlayerState : BasePlayerState
    {
        public float CurrentSpeed { get; private set; }

        private float MovementInertia => playerData.PlayerConfiguration.MovementInertia;
        private Transform PlayerTransform => playerData.PlayerTransform;
        private Vector3 CurrentPlayerPosition => PlayerTransform.position;

        public MovingPlayerState(PlayerData playerData) : base(playerData)
        {
        }

        public override void Enter()
        {
            Debug.Log("Moving");
            playerData.PlayerAnimator.PlayRun();
        }

        public override void Update()
        {
            MovePlayer();
        }

        public override void Exit()
        {
        }

        private void MovePlayer()
        {
            var targetXPosition = GetClampedPosition(PlayerInput.CursorWorldPosition.x);
            var newXPosition = Mathf.Lerp(CurrentPlayerPosition.x, targetXPosition, MovementInertia * Time.deltaTime);

            CurrentSpeed = Mathf.Abs(newXPosition - CurrentPlayerPosition.x) / Time.deltaTime;

            PlayerTransform.position = new Vector3(newXPosition, CurrentPlayerPosition.y, CurrentPlayerPosition.z);
        }

        private float GetClampedPosition(float position)
        {
            var bounds = playerData.PlayerRenderer.bounds;

            var minX = CameraHolder.ScreenBounds.x + bounds.extents.x;
            var maxX = CameraHolder.ScreenBounds.y - bounds.extents.x;

            var clampedPosition = Mathf.Clamp(position, minX, maxX);

            return clampedPosition;
        }
    }
}