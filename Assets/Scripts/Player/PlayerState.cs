using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    private string animBoolName;
    protected Rigidbody2D rb;
    protected float stateTimer;
    protected bool isTriggerCalled;
    protected Vector2 playerGravity;
    protected float xInput;
    protected float yInput;
    protected UserInputManager userInput;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player.animator.SetBool(animBoolName, true);
        rb = player.rb;
        playerGravity = new Vector2(0, -Physics2D.gravity.y);
        isTriggerCalled = false;
        userInput = UserInputManager.instance;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;

        xInput = userInput.horizontalMovement().x;

        player.animator.SetFloat("yVelocity", rb.velocity.y);
    }

    public virtual void Exit() => player.animator.SetBool(animBoolName, false);
    public virtual void animationFinishTrigger() => isTriggerCalled = true;
}
