using UnityEngine;

public class PlayerJumpDescendState : PlayerAiredState
{
    public PlayerJumpDescendState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        //
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (player.isGrounded())
            stateMachine.ChangeState(player.idleState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
