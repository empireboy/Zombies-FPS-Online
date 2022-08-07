using UnityEngine;
using Zenject;

public class PlayerClientInstaller : MonoInstaller
{
    [SerializeField]
    private Component[] _componentsToDestroy;

    public override void InstallBindings()
    {
        DestroyComponents();

        Container.Bind<PlayerSpawner>().AsSingle();
    }

    private void DestroyComponents()
    {
        foreach (Component component in _componentsToDestroy)
            Destroy(component);
    }
}