using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        //        
    }

    public override void Enter()
    {
        base.Enter();
        player.setVelocity(0f, rb.linearVelocity.y);
    }

    public override void Update()
    {
        base.Update();

        // Jump
        if (inputControl.Player.Jump.WasPressedThisFrame() && player.coyoteTimeCounter > 0f)
            stateMachine.ChangeState(player.jumpAscendState);

        // Coyote Time
        if (player.isGrounded())
            player.coyoteTimeCounter = player.coyoteTime;
        else if (!player.isGrounded() && player.coyoteTimeCounter > 0f)
            player.coyoteTimeCounter -= Time.deltaTime;
        else
            stateMachine.ChangeState(player.jumpDescendState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
