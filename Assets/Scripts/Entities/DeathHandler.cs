using Zenject;

public class DeathHandler : IActivatable
{
    public bool IsActive { get; set; }

    private readonly StateController _stateController;
    private readonly State _dyingState;

    public DeathHandler(StateController stateController, [Inject(Id = "Dying State")] State dyingState)
    {
        _dyingState = dyingState;
        _stateController = stateController;

        IsActive = true;
    }

    public void Kill()
    {
        if (!IsActive)
            return;

        _stateController.TransitionToState(_dyingState);
    }
}