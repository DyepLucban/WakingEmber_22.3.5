using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayerJumpAscendState : OldPlayerState
{
    public OldPlayerJumpAscendState(OldPlayer _player, OldPlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.setVelocity(rb.linearVelocity.x, player.jumpForce);
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
            player.setVelocity(xInput * player.aerialMovementSpeed, rb.linearVelocity.y);
            player.Flip(xInput);
        }

        // If jump button is released, it will not jump higher
        if (userInput.playerJump.WasReleasedThisFrame() && rb.linearVelocity.y > 0f)
            player.setVelocity(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);

        // Transition to descend state
        if (rb.linearVelocity.y < 0)
            stateMachine.ChangeState(player.jumpDescendState);
    }
}
