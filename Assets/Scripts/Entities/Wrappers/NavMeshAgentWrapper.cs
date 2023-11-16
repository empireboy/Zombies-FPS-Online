using UnityEngine.AI;

public class NavMeshAgentWrapper : IActivatable
{
    public bool IsActive
    {
        get
        {
            return _agent.enabled;
        }
        set
        {
            _agent.enabled = value;
        }
    }

    private readonly NavMeshAgent _agent;

    public NavMeshAgentWrapper(NavMeshAgent agent)
    {
        _agent = agent;
    }
}