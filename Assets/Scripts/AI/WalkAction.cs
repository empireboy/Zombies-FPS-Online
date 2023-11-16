using CM.Debugging;
using UnityEngine;

[CreateAssetMenu(menuName = "State Machine/Walk Action")]
public class WalkAction : Action
{
    public override void Act(IActor actor)
    {

    }

    public override void OnActionStart(IActor actor)
    {
        if (actor is IEnemyActor enemyActor)
        {
            enemyActor.MoveTowards(() => Camera.main.transform.position);
        }
        else
        {
            CM_Debug.LogError("State Machine", "Actor is not an IEnemyActor so calling MoveTowards on it won't work");
        }
    }
}
