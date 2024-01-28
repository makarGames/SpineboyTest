using PlayerLogic;

namespace SateMachineLogic.PlayerStates
{
    public abstract class BasePlayerState : IState
    {
        protected PlayerData playerData;

        protected BasePlayerState(PlayerData playerData)
        {
            this.playerData = playerData;
        }

        public abstract void Enter();

        public abstract void Update();

        public abstract void Exit();
    }
}