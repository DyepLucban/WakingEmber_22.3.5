using UnityEngine;

public class PlayerJumpDescendState : PlayerState
{
    public PlayerJumpDescendState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        //
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (player.isGrounded())
            stateMachine.ChangeState(player.idleState);
        
        // Player can move while descending
        if (player.moveInput.x != 0)
        {
            player.setVelocity((player.moveInput.x * player.aerialMovement) - 1f, rb.linearVelocity.y);
            player.handleFlip(player.moveInput.x);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
