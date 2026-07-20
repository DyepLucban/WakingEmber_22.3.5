using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayerIdleState : OldPlayerGroundedState
{
    public OldPlayerIdleState(OldPlayer _player, OldPlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.setVelocityToZero();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (xInput != 0 && !player.isBusy)
            stateMachine.ChangeState(player.moveState);
    }
}
