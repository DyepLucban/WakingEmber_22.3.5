using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log($"Im in {animBoolName}");
        // Additional code for entering the move state
    }

    public override void Update()
    {
        base.Update();

        player.setVelocity(player.moveInput.x * player.movementSpeed, rb.linearVelocity.y);

        // Player stops moving, change to idle state
        if (player.moveInput.x == 0)
            stateMachine.ChangeState(player.idleState);

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
