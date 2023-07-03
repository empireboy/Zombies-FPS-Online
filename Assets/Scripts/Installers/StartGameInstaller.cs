using UnityEngine;
using Zenject;
using System.Linq;
using Unity.Netcode;

public class StartGameInstaller : MonoInstaller
{
    [SerializeField]
    private string _enemySpawnTag = "Enemy Spawn";

    [SerializeField]
    private Enemy _enemyPrefab;

    public override void InstallBindings()
    {
        if (!NetworkManager.Singleton.IsHost)
            return;

        GameObject[] spawnObjects = GameObject.FindGameObjectsWithTag(_enemySpawnTag);
        Vector3[] spawnPositions = spawnObjects.Select(x => x.transform.position).ToArray();

        Container.BindInterfacesTo<EnemySpawnManager>()
            .AsSingle()
            .WithArguments(_enemyPrefab, spawnPositions);
    }
 }
