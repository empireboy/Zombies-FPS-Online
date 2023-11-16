using UnityEngine;

/// <summary>
/// The scriptable object for a state for in the state machine.
/// </summary>
[CreateAssetMenu(menuName = "State Machine/State")]
public class State : ScriptableObject
{
    /// <summary>
    /// An array of all the actions from the current state.
    /// </summary>
    public Action[] actions;

    /// <summary>
    /// An array of all the transitions to another state.
    /// </summary>
    public Transition[] transitions;

    /// <summary>
    /// The color for displaying a debuging box around the object.
    /// </summary>
    public Color gizmoColor = Color.white;

    /// <summary>
    /// This function starts transitions for this state.
    /// </summary>
    public void StartState(IActor actor)
    {
        StartActions(actor);
        StartTransitions(actor);
    }

    /// <summary>
    /// This function updates the actions and transitions for this state.
    /// </summary>
    public void UpdateState(IActor actor)
    {
        UpdateActions(actor);
        CheckTransitions(actor);
    }

    private void StartActions(IActor actor)
    {
        int length = actions.Length;

        for (int i = 0; i < length; i++)
        {
            actions[i].OnActionStart(actor);
        }
    }

    private void UpdateActions(IActor actor)
    {
        int length = actions.Length;

        for (int i = 0; i < length; i++)
        {
            actions[i].Act(actor);
        }
    }

    private void StartTransitions(IActor actor)
    {
        int length = transitions.Length;

        for (int i = 0; i < length; i++)
        {
            transitions[i].decision.OnDecisionStart(actor);
        }
    }


    private void CheckTransitions(IActor actor)
    {
        int length = transitions.Length;

        for (int i = 0; i < length; i++)
        {
            Transition transition = transitions[i];

            actor.StateController.TransitionToState(transition.decision.Decide(actor) ? transition.trueState : transition.falseState);
        }
    }
}
