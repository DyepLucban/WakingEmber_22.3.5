using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayer : Entity
{
    #region Movement, Jumps
    [Header("Movement Variables")]
    public float moveSpeed;
    public float aerialMovementSpeed;

    [Header("Jump Variables")]
    public float jumpForce;
    public float jumpFallMultiplier;
    public float coyoteTime;
    public float coyoteTimeCounter;
    #endregion

    #region Collision Checks
    [Header("Collision Checks")]
    [SerializeField] Transform groundChecker;
    [SerializeField] Vector2 groundCheckerSize;
    [SerializeField] LayerMask groundLayer;
    #endregion

    #region Attack Details
    [Header("Attack Details")]
    public Vector2[] attackMovements;
    public bool isBusy { get; private set; }
    public Transform attackChecker;
    public float attackCheckerRadius;
    #endregion

    #region States
    public OldPlayerStateMachine stateMachine { get; private set; }
    public OldPlayerIdleState idleState { get; private set; }
    public OldPlayerMoveState moveState { get; private set; }
    public OldPlayerJumpAscendState jumpAscendState { get; private set; }
    public OldPlayerJumpDescendState jumpDescendState { get; private set; }
    public OldPlayerAttackState attackState { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new OldPlayerStateMachine();

        idleState = new OldPlayerIdleState(this, stateMachine, "isIdle");
        moveState = new OldPlayerMoveState(this, stateMachine, "isMoving");
        jumpAscendState = new OldPlayerJumpAscendState(this, stateMachine, "isJumping");
        jumpDescendState = new OldPlayerJumpDescendState(this, stateMachine, "isJumping");
        attackState = new OldPlayerAttackState(this, stateMachine, "isAttacking");

    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        
        stateMachine.currentState.Update();

        coyoteTimeCounter -= Time.deltaTime;
    }

    public bool isGrounded() => Physics2D.OverlapBox(groundChecker.position, groundCheckerSize, 0, groundLayer);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(groundChecker.position, groundCheckerSize);
        Gizmos.DrawWireSphere(attackChecker.position, attackCheckerRadius);
    }
    public void oldAnimationTrigger() => stateMachine.currentState.animationFinishTrigger();
    public IEnumerator busyFor(float _seconds)
    {
        isBusy = true;
        yield return new WaitForSeconds(_seconds);
        isBusy = false;
    }
}
