using UnityEngine;

public class PlayerAiredState : PlayerState
{
    public PlayerAiredState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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

        // Player can move while in the air
        if (player.moveInput.x != 0)
        {
            player.setVelocity(player.moveInput.x * player.aerialMovement, rb.linearVelocity.y);
            player.handleFlip(player.moveInput.x);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
