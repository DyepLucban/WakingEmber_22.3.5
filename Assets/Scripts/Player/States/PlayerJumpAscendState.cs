using UnityEngine;

public class PlayerJumpAscendState : PlayerAiredState
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
    }

    public override void Exit()
    {
        base.Exit();
    }
}
