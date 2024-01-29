using Infrastructure;
using SateMachineLogic;
using SateMachineLogic.PlayerStates;
using UnityEngine;
using Utils;

namespace PlayerLogic
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;

        private StateMachine _stateMachine;

        public PlayerData PlayerData => _playerData;

        private void Start()
        {
            InitializeStateMachine();
        }

        private void Update()
        {
            _stateMachine.UpdateCurrentState();
        }

        private void LateUpdate()
        {
            CheckMovingThreshold();
        }

        private void InitializeStateMachine()
        {
            var idleState = new IdlePlayerState(_playerData);
            var movingState = new MovingPlayerState(_playerData);

            var states = new IState[]
            {
                idleState,
                movingState
            };

            _stateMachine = new StateMachine(states);
            _stateMachine.SetCurrentState<IdlePlayerState>();
        }

        private void CheckMovingThreshold()
        {
            if (_stateMachine.CurrentStateType != typeof(MovingPlayerState))
            {
                var currentDistance = Mathf.Abs(PlayerInput.CursorWorldPosition.x - _playerData.PlayerTransform.position.x);

                if (CursorInsideBounds() && currentDistance > _playerData.PlayerConfiguration.CursorDistanceThreshold)
                {
                    _stateMachine.SetCurrentState<MovingPlayerState>();
                }
            }
            else if (((MovingPlayerState)_stateMachine.CurrentState).CurrentSpeed <=
                     _playerData.PlayerConfiguration.MovementSpeedThreshold)
            {
                _stateMachine.SetCurrentState<IdlePlayerState>();
            }
        }

        private bool CursorInsideBounds()
        {
            var bounds = _playerData.PlayerRenderer.bounds;

            var minX = CameraHolder.ScreenBounds.x + bounds.extents.x;
            var maxX = CameraHolder.ScreenBounds.y - bounds.extents.x;

            var cursorInsideBounds = (PlayerInput.CursorWorldPosition.x >= minX && PlayerInput.CursorWorldPosition.x <= maxX);

            return cursorInsideBounds;
        }
    }
}