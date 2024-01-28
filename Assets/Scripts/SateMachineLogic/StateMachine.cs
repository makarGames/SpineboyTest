using System;
using System.Collections.Generic;

namespace SateMachineLogic
{
    public class StateMachine
    {
        private Dictionary<Type, IState> _statesMap = new();
        private IState _currentState;

        public StateMachine(IEnumerable<IState> states)
        {
            foreach (var state in states)
            {
                _statesMap.Add(state.GetType(), state);
            }
        }

        public void SetCurrentState<T>() where T : IState
        {
            var newState = GetState<T>();
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        private T GetState<T>() where T : IState
        {
            var type = typeof(T);
            return (T)_statesMap[type];
        }

        public void UpdateCurrentState()
        {
            _currentState.Update();
        }
    }
}