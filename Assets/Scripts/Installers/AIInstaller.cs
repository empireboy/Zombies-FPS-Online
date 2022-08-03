using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class AIInstaller : MonoInstaller
{
    [SerializeField]
    private StateController _stateController;

    [SerializeField]
    private State _startingState;

    [SerializeField]
    private State _dyingState;

    public override void InstallBindings()
    {
        Container.Bind<StateController>()
            .FromInstance(_stateController)
            .AsSingle();

        Container.Bind<NavMeshAgent>()
            .FromComponentInChildren()
            .AsSingle();

        Container.Bind<Animator>()
            .FromComponentInChildren()
            .AsSingle();

        Container.Bind<State>()
            .WithId("Starting State")
            .FromInstance(_startingState)
            .AsTransient();

        Container.Bind<State>()
            .WithId("Dying State")
            .FromInstance(_dyingState)
            .AsTransient();
    }
}