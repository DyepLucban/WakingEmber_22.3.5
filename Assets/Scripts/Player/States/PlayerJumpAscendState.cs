using UnityEngine;

public class PlayerJumpAscendState : PlayerState
{
    public PlayerJumpAscendState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName) {}

    public override void Enter()
    {
        base.Enter();

        player.setVelocity(rb.linearVelocity.x, player.jumpForce);
    }

    public override void Update()
    {
        base.Update();

        if (rb.linearVelocity.y < 0)
            stateMachine.ChangeState(player.jumpDescendState);

        // Player can move while in the air
        if (player.moveInput.x != 0)
        {
            player.setVelocity(player.moveInput.x * player.aerialMovement, rb.linearVelocity.y);
            player.handleFlip(player.moveInput.x);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
