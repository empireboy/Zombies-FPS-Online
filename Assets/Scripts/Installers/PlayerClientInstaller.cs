using UnityEngine;
using Zenject;

public class PlayerClientInstaller : MonoInstaller
{
    [SerializeField]
    private Component[] _componentsToDestroy;

    [SerializeField]
    private Transform _playerRoot;

    public override void InstallBindings()
    {
        DestroyComponents();

        Container.Bind<Transform>().FromInstance(_playerRoot).AsSingle();
        Container.Bind<PlayerSpawner>().AsSingle();
    }

    private void DestroyComponents()
    {
        foreach (Component component in _componentsToDestroy)
            Destroy(component);
    }
}
