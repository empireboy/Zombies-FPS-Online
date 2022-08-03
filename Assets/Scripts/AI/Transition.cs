/// <summary>
/// A class that controls the transition from one state to another.
/// </summary>
[System.Serializable]
public class Transition
{
    /// <summary>
    /// This decision decides if the state has to transition to the true or false state.
    /// </summary>
    public Decision decision;

    /// <summary>
    /// The state to change in when the decision is true.
    /// </summary>
    public State trueState;

    /// <summary>
    /// The state to change in when the decision is false.
    /// </summary>
    public State falseState;
}
