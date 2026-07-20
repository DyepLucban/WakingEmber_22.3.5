using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        // Additional code for entering the idle state
    }

    public override void Update()
    {
        base.Update();
        if (player.moveInput.x != 0)
            stateMachine.ChangeState(player.moveState);
        // Additional code for updating the idle state
    }

    public override void Exit()
    {
        base.Exit();
        // Additional code for exiting the idle state
    }
}
