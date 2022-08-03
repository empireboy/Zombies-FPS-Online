using UnityEngine;

[CreateAssetMenu(menuName = "State Machine/Animation Action")]
public class StringAnimationAction : AnimationAction<string>
{
    protected override void PlayAnimation(StateController sc, string animation)
    {
        sc.animator.Play(animation);
    }
}
