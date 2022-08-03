using UnityEngine;
using Zenject;

public class GunInstaller : MonoInstaller
{
    [SerializeField]
    private Transform _shootTransform;

    [SerializeField]
    private Transform _muzzleFlashTransform;

    public override void InstallBindings()
    {
        Container.Bind<IShoot>()
            .To<RaycastShoot>()
            .AsSingle()
            .WithArguments(_shootTransform, _muzzleFlashTransform);
    }
}