using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        //        
    }

    public override void Enter()
    {
        base.Enter();
        player.setVelocity(0f, rb.linearVelocity.y);
    }

    public override void Update()
    {
        base.Update();

        if (inputControl.Player.Jump.WasPressedThisFrame() && player.isGrounded())
            stateMachine.ChangeState(player.jumpAscendState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
