using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayerJumpDescendState : OldPlayerState
{
    public OldPlayerJumpDescendState(OldPlayer _player, OldPlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (rb.linearVelocity.y < 0)
            rb.linearVelocity -= playerGravity * player.jumpFallMultiplier * Time.deltaTime;

        if (xInput != 0)
        {
            player.setVelocity(xInput * player.aerialMovementSpeed, rb.linearVelocity.y);
            player.Flip(xInput);
        }

        if (player.isGrounded())
            stateMachine.ChangeState(player.idleState);
    }
}
