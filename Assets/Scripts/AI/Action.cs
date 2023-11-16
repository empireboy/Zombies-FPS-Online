using UnityEngine;

public abstract class Action : ScriptableObject
{
    public abstract void Act(IActor actor);

    public virtual void OnActionStart(IActor actor) { }
}
