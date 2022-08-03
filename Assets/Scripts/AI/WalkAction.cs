using UnityEngine;

[CreateAssetMenu(menuName = "State Machine/Walk Action")]
public class WalkAction : Action
{
    public float speedMin = 1;
    public float speedMax = 3;
    public float walkAnimationMultiplier = 1;

    public override void Act(StateController sc)
    {
        sc.navMeshAgent.SetDestination(Camera.main.transform.position);
    }

    public override void OnActionStart(StateController sc)
    {
        sc.navMeshAgent.speed = Random.Range(speedMin, speedMax);

        sc.animator.speed = sc.navMeshAgent.speed * walkAnimationMultiplier;
    }
}
