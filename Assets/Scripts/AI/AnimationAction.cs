using CM.Debugging;
using UnityEngine;

[CreateAssetMenu(menuName = "State Machine/Animation Action")]
public class AnimationAction : Action
{
    [SerializeField]
    private string animation;

    public override void Act(IActor actor)
    {
        return;
    }

    public override void OnActionStart(IActor actor)
    {
        if (actor == null)
        {
            CM_Debug.LogError("State Machine", "Actor is null. Can't play animation");
            return;
        }

        PlayAnimation(actor, animation);
    }

    private void PlayAnimation(IActor actor, string animation)
    {
        if (actor is IAnimatable animatable)
        {
            animatable.PlayAnimation(animation);
        }
        else
        {
            CM_Debug.LogError("State Machine", "Actor is not an IAnimatable so playing animations on it won't work");
        }
    }
}
