using System;
using System.Collections.Generic;
using CharacterLogic;
using SateMachineLogic;
using SateMachineLogic.PlayerStates;
using ScriptableObjects.Classes;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace PlayerLogic
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;

        private StateMachine _stateMachine;

        private void Awake()
        {
            InitializeStateMachine();
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
    }
}