using CM.Debugging;
using UnityEngine;

[CreateAssetMenu(menuName = "State Machine/Stop Walk Action")]
public class StopWalkAction : Action
{
    public override void Act(IActor actor)
    {
        return;
    }

    public override void OnActionStart(IActor actor)
    {
        if (actor is IEnemyActor enemyActor)
        {
            enemyActor.Stop();
        }
        else
        {
            CM_Debug.LogError("State Machine", "Actor is not an IEnemyActor so calling Stop on it won't work");
        }

        //sc.navMeshAgent.isStopped = true;
    }
}
