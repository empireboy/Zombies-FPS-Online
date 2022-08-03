using UnityEngine.AI;
using UnityEngine;
using Zenject;

/// <summary>
/// The controller of the AI, this is the brain that controlls the AI.
/// </summary>
public class StateController : MonoBehaviour
{
    /// <summary>
    /// A reference to the NavMeshAgent component, this component controlls the villager his movement on the NavMesh.
    /// </summary>
    [HideInInspector]
    public NavMeshAgent navMeshAgent;

	/// <summary>
	/// A reference to the Animation component, this component has all animations for the villager.
	/// </summary>
	[HideInInspector]
	public Animator animator;

	/// <summary>
	/// The destination the villager has to reach while in one of the walking states.
	/// </summary>
	[HideInInspector]
    public Vector3 targetDestination;

    // The current state in which the AI currently is.
    [SerializeField] private State _currentState = null;

    [Inject]
    public void Construct(NavMeshAgent navMeshAgent, Animator animator, [Inject(Id = "Starting State")] State startingState)
    {
        this.navMeshAgent = navMeshAgent;
        this.animator = animator;
        _currentState = startingState;
    }

    // The awake function is used to set all the references.
    private void Awake()
    {
        //navMeshAgent = GetComponent<NavMeshAgent>();
		//animation = GetComponent<Animation>();
	}

    private void Start()
    {
        _currentState.StartState(this);
    }

    // The update function is here to update the current state.
    private void Update()
    {
        _currentState.UpdateState(this);
    }

    /// <summary>
    /// This function transitions the current state to the new state
    /// </summary>
    /// <param name="nextState">The next state the AI has to go into.</param>
    public void TransitionToState(State nextState)
    {
        if (nextState)
        {
            if (nextState != _currentState)
            {
                _currentState = nextState;
                nextState.StartState(this);
            }
        }
    }

#region Editor Region
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
#endregion
}
