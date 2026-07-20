using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayerAttackState : OldPlayerGroundedState
{
    private int comboCounter;
    private float lastTimeAttacked;
    private float comboWindows = 2f;

    public OldPlayerAttackState(OldPlayer _player, OldPlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if (comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindows)
            comboCounter = 0;

        player.animator.SetInteger("comboCounter", comboCounter);

        player.setVelocity(player.attackMovements[comboCounter].x * -player.facingDir, player.attackMovements[comboCounter].y);

        stateTimer = 0.15f;
    }

    public override void Exit()
    {
        base.Exit();

        player.StartCoroutine("busyFor", 0.15f);
        comboCounter++;
        lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            player.setVelocityToZero();

        if (isTriggerCalled)
            stateMachine.ChangeState(player.idleState);
    }
}
