using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class AIInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _rootObject;

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private State _startingState;

    [SerializeField]
    private State _dyingState;

    public override void InstallBindings()
    {
        Enemy enemy = _rootObject.GetComponent<IActor>() as Enemy;

        Container.Bind<IActor>()
            .To<Enemy>()
            .FromInstance(enemy)
            .AsSingle();

        Container.BindInterfacesTo<StateController>().AsSingle();
        Container.Bind<NavMeshAgentWrapper>().AsSingle();
        Container.Bind<AnimationManager>().AsSingle();

        Container.Bind<NavMeshAgent>()
            .FromInstance(agent)
            .AsSingle();

        Container.Bind<Animator>()
            .FromInstance(animator)
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