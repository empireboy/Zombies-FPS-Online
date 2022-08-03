using Unity.Netcode;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField]
    private Transform _playerRoot;

    [SerializeField]
    private Transform _playerHead;

    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private Transform _weaponTransform;

    [SerializeField]
    private Transform _shootTransform;

    public override void InstallBindings()
    {
        Container.Bind<PlayerInputState>().AsSingle();
        Container.Bind<PlayerSpawner>().AsSingle();

        Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
        Container.BindInterfacesTo<PlayerActionHandler>().AsSingle();

        Container.BindInterfacesTo<RigidbodyMovement>()
            .AsSingle()
            .WithArguments(_rigidbody);

        Container.BindInterfacesTo<AxisRotator>()
            .AsTransient()
            .WithConcreteId("Player Root")
            .WithArguments(_playerRoot);

        Container.BindInterfacesTo<AxisRotator>()
            .AsTransient()
            .WithConcreteId("Player Head")
            .WithArguments(_playerHead);

        Container.BindInterfacesTo<Sway>()
            .AsSingle()
            .WithArguments(_weaponTransform);
    }
}