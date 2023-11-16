using Zenject;

public class StateController : IStateController, ITickable
{
    private IActor _actor;

    private State _currentState;

    public StateController([Inject(Id = "Starting State")] State startingState)
    {
        _currentState = startingState;
    }

    public void SetActor(IActor actor)
    {
        _actor = actor;

        _currentState.StartState(_actor);
    }

    public void Tick()
    {
        if (_actor == null)
            return;

        _currentState.UpdateState(_actor);
    }

    /// <summary>
    /// This function transitions the current state to the new state.
    /// </summary>
    /// <param name="nextState">The next state the AI has to go into.</param>
    public void TransitionToState(State nextState)
    {
        if (_actor == null)
            return;

        if (!nextState)
            return;

        if (nextState == _currentState)
            return;

        _currentState = nextState;
        nextState.StartState(_actor);
    }

/*#region Editor Region
#if UNITY_EDITOR

    // Reference to the renderer component 
    private Renderer _renderer;

    private void OnValidate()
    {
        if (GetComponentInChildren<Renderer>())
            _renderer = GetComponentInChildren<Renderer>();
    }

    // Display a box around the object to debug in which state the object is.
    private void OnDrawGizmosSelected()
    {
        if (_currentState)
        {
            if (_renderer)
            {
                Gizmos.color = _currentState.gizmoColor;
                Gizmos.DrawWireCube(_renderer.bounds.center, _renderer.bounds.size);
            }
            else
            {
                Gizmos.color = _currentState.gizmoColor;
                Gizmos.DrawWireCube(transform.position, transform.localScale);
            }

			Gizmos.color = _currentState.gizmoColor;
			Gizmos.DrawWireSphere(targetDestination, 0.5f);
		}
    }

#endif
#endregion*/
}