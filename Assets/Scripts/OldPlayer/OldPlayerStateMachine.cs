public class OldPlayerStateMachine
{
    public OldPlayerState currentState { get; private set; }

    public void Initialize(OldPlayerState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(OldPlayerState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
