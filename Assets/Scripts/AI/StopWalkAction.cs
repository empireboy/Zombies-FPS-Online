using UnityEngine;

[CreateAssetMenu(menuName = "State Machine/Stop Walk Action")]
public class StopWalkAction : Action
{
    public override void Act(StateController sc)
    {
        return;
    }

    public override void OnActionStart(StateController sc)
    {
        sc.navMeshAgent.isStopped = true;
    }
}
