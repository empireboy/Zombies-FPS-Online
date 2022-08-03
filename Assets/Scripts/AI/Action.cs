using UnityEngine;

/// <summary>
/// This class contains the action that has to be executed.
/// </summary>
public abstract class Action : ScriptableObject
{
    /// <summary>
    /// This function executes the action.
    /// </summary>
    /// <param name="sc">Takes in the StateController class.</param>
    public abstract void Act(StateController sc);

    /// <summary>
    /// An optional start function
    /// </summary>
    /// <param name="sc">Takes in the StateController class.</param>
    public virtual void OnActionStart(StateController sc) { }
}
