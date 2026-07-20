using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayerMoveState : OldPlayerGroundedState
{
    public OldPlayerMoveState(OldPlayer _player, OldPlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.setVelocity(xInput * player.moveSpeed, rb.linearVelocity.y);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        player.setVelocity(xInput * player.moveSpeed, rb.linearVelocity.y);

        player.Flip(xInput);

        if(xInput == 0)
            stateMachine.ChangeState(player.idleState);
    }
}
