using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log($"Im in {stateName}");
        // Additional code for entering the move state
    }

    public override void Update()
    {
        base.Update();
        // Additional code for updating the move state
        if (player.moveInput.x == 0)
            stateMachine.ChangeState(player.idleState);
    }

    public override void Exit()
    {
        base.Exit();
        // Additional code for exiting the move state
    }
}
