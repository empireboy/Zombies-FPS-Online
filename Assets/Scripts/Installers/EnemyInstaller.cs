using Zenject;

public class EnemyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //Container.Bind<DeathHandler>().AsSingle();
        Container.BindInterfacesAndSelfTo<EnemyMovementHandler>().AsSingle();
    }
}