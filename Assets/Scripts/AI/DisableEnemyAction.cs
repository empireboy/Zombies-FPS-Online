using UnityEngine;

[CreateAssetMenu(menuName = "State Machine/Disable Enemy Action")]
public class DisableEnemyAction : Action
{
    public override void Act(IActor actor)
    {
        return;
    }

    public override void OnActionStart(IActor actor)
    {
        if (actor is IComponentContainer componentContainer)
        {
            componentContainer.Components.SetActive<IHealth>(false);
            componentContainer.Components.SetActive<NavMeshAgentWrapper>(false);
        }
    }
}
