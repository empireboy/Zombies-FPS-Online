using Zenject;

public class GameInstaller : MonoInstaller
{
    /*[SerializeField]
    private string _enemySpawnTag = "Enemy Spawn";

    [SerializeField]
    private Enemy _enemyPrefab;*/

    public override void InstallBindings()
    {
        /*GameObject[] spawnObjects = GameObject.FindGameObjectsWithTag(_enemySpawnTag);
        Vector3[] spawnPositions = spawnObjects.Select(x => x.transform.position).ToArray();

        Container.BindInterfacesTo<EnemySpawnManager>()
            .AsSingle()
            .WithArguments(_enemyPrefab, spawnPositions);*/

        Container.Bind<PlayerManager>().AsSingle();
    }
 }
