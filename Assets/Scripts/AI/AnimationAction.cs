using UnityEngine;

public abstract class AnimationAction<T> : Action
{
    [SerializeField]
    protected T animation;

    public override void Act(StateController sc)
    {
        return;
    }

    public override void OnActionStart(StateController sc)
    {
        PlayAnimation(sc, animation);
    }

    protected abstract void PlayAnimation(StateController sc, T animation);
}
