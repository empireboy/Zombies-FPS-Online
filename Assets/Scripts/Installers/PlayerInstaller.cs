using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField]
    private Transform _playerRoot;

    [SerializeField]
    private Transform _playerHead;

    [SerializeField]
    private CharacterController _characterController;

    [SerializeField]
    private Transform _weaponTransform;

    [SerializeField]
    private Transform _shootTransform;

    public override void InstallBindings()
    {
        Container.Bind<PlayerInputState>().AsSingle();
        Container.Bind<PlayerSpawner>().AsSingle();
        Container.Bind<Transform>().FromInstance(_playerRoot).AsSingle();

        Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
        Container.BindInterfacesTo<PlayerActionHandler>().AsSingle();

        Container.BindInterfacesTo<CharacterControllerMovement>()
            .AsSingle()
            .WithArguments(_characterController);

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