using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayerGroundedState : OldPlayerState
{
    public OldPlayerGroundedState(OldPlayer _player, OldPlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        // Attacking
        if (userInput.playerAttack.WasPressedThisFrame() && player.isGrounded())
            stateMachine.ChangeState(player.attackState);

        // Coyote Time
        if (player.isGrounded())
            player.coyoteTimeCounter = player.coyoteTime;
        else if (!player.isGrounded() && player.coyoteTimeCounter > 0f)
            player.coyoteTimeCounter -= Time.deltaTime;
        else
            stateMachine.ChangeState(player.jumpDescendState);

        // For Jump
        if (userInput.playerJump.WasPressedThisFrame() && player.coyoteTimeCounter > 0f)
            stateMachine.ChangeState(player.jumpAscendState);
    }
}
