using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpAscendState : PlayerState
{
    public PlayerJumpAscendState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.setVelocity(rb.velocity.x, player.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        // Do aerial movement
        if (xInput != 0)
        {
            player.setVelocity(xInput * player.aerialMovementSpeed, rb.velocity.y);
            player.Flip(xInput);
        }

        // If jump button is released, it will not jump higher
        if (userInput.playerJump.WasReleasedThisFrame() && rb.velocity.y > 0f)
            player.setVelocity(rb.velocity.x, rb.velocity.y * 0.5f);

        // Transition to descend state
        if (rb.velocity.y < 0)
            stateMachine.ChangeState(player.jumpDescendState);
    }
}
