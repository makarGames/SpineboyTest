using System;
using System.Collections.Generic;

namespace SateMachineLogic
{
    public class StateMachine
    {
        private Dictionary<Type, IState> _statesMap = new();
        public IState CurrentState { get; private set; }
        public Type CurrentStateType { get; private set; }
        
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
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentStateType = typeof(T);
            CurrentState.Enter();
        }

        private T GetState<T>() where T : IState
        {
            var type = typeof(T);
            return (T)_statesMap[type];
        }

        public void UpdateCurrentState()
        {
            CurrentState.Update();
        }
    }
}