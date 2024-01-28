using PlayerLogic;
using UnityEngine;

namespace SateMachineLogic.PlayerStates
{
    public class IdlePlayerState : BasePlayerState
    {
        public IdlePlayerState(PlayerData playerData) : base(playerData)
        {
          
        }
        
        public override void Enter()
        {
            Debug.Log("Idle");
            playerData.PlayerAnimator.PlayIdle();
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
        }
    }
}