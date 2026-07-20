using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInputControl inputControl;
    private StateMachine stateMachine;

    #region States
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    #endregion

    public Vector2 moveInput { get; private set; }

    private void Awake()
    {
        stateMachine = new StateMachine();
        inputControl = new PlayerInputControl();

        idleState = new PlayerIdleState(this, stateMachine, "IdleState");
        moveState = new PlayerMoveState(this, stateMachine, "moveState");

    }

    private void OnEnable()
    {
        inputControl.Enable();
        inputControl.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputControl.Player.Movement.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    private void Start()
    {
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }
}
