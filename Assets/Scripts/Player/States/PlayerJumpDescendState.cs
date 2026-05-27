using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpDescendState : PlayerState
{
    public PlayerJumpDescendState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        if (rb.velocity.y < 0)
            rb.velocity -= playerGravity * player.jumpFallMultiplier * Time.deltaTime;

        if (xInput != 0)
        {
            player.setVelocity(xInput * player.aerialMovementSpeed, rb.velocity.y);
            player.Flip(xInput);
        }

        if (player.isGrounded())
            stateMachine.ChangeState(player.idleState);
    }
}
