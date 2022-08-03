using UnityEngine;

[CreateAssetMenu(menuName = "State Machine/Zombie Animation Action")]
public class ZombieAnimationAction : AnimationAction<ZombieAnimations>
{
    protected override void PlayAnimation(StateController sc, ZombieAnimations animation)
    {
        sc.animator.Play(animation.ToString());
    }
}
