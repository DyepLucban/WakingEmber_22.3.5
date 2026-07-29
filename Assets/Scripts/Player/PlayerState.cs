using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected StateMachine stateMachine;
    protected string animBoolName;
    protected Animator anim;
    protected Rigidbody2D rb;
    protected PlayerInputControl inputControl;

    public PlayerState(Player player, StateMachine stateMachine, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        anim = player.anim;
        rb = player.rb;
        inputControl = player.inputControl;
    }

    public virtual void Enter()
    {
        // Code to execute when entering the state
        anim.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
        // Code to execute every frame while in the state
    }

    public virtual void Exit()
    {
        // Code to execute when exiting the state
        anim.SetBool(animBoolName, false);
    }
}
