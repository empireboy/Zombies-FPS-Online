using UnityEngine;

[CreateAssetMenu(menuName = "State Machine/Disable Enemy Action")]
public class DisableEnemyAction : Action
{
    public override void Act(StateController sc)
    {
        return;
    }

    public override void OnActionStart(StateController sc)
    {
        sc.GetComponent<IComponentContainer>().Components.SetActive<IHealth>(false);

        sc.navMeshAgent.enabled = false;
    }
}
