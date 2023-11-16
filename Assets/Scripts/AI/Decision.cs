using UnityEngine;

public abstract class Decision : ScriptableObject
{
    public abstract bool Decide(IActor actor);

    public virtual void OnDecisionStart(IActor actor) { }
}