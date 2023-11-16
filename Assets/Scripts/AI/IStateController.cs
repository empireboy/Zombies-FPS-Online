public interface IStateController
{
    void SetActor(IActor actor);
    void TransitionToState(State nextState);
}