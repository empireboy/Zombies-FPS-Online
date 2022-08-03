using UnityEngine;
using Zenject;

public class HealthInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _gameObject;

    public override void InstallBindings()
    {
        Container.Bind<IHealth>()
            .To<Health>()
            .AsSingle();
    }
}