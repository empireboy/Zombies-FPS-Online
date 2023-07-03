using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Zenject;

public class EnemySpawnManager : ITickable, IActivatable
{
    public bool IsActive { get; set; }

    private readonly Settings _settings;
    private readonly DiContainer _container;
    private readonly PlayerManager _playerManager;
    private readonly Enemy _enemyPrefab;
    private readonly Vector3[] _spawnPositions;

    private float _spawnTimer;
    private float _spawnTime;

    private int _currentEnemies;
    private int _maxEnemies;

    public EnemySpawnManager(Settings settings, DiContainer container, PlayerManager playerManager, Enemy enemyPrefab, Vector3[] spawnPositions)
    {
        _settings = settings;
        _container = container;
        _playerManager = playerManager;
        _enemyPrefab = enemyPrefab;
        _spawnPositions = spawnPositions;

        _spawnTime = _settings.spawnTime;
        _maxEnemies = _settings.maxEnemies;

        IsActive = true;
    }

    public void Tick()
    {
        Debug.Log("TEST");

        if (!IsActive)
            return;

        // TEST
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _currentEnemies = 0;
            _spawnTimer = 0;
            _maxEnemies = (int)Mathf.Round(_maxEnemies * 1.5f);
        }

        if (_currentEnemies >= _maxEnemies)
            return;

        if (_spawnTimer >= _spawnTime)
            SpawnEnemy();

        _spawnTimer += Time.deltaTime / 10f;
    }

    private void SpawnEnemy()
    {
        Vector3[] spawnPositionsCloseToPlayer = new Vector3[_spawnPositions.Length];
        List<Vector3> spawnPositionsTemp = new List<Vector3>(_spawnPositions);

        // Get all spawn positions sorted, close to the player
        for (int i = 0; i < _spawnPositions.Length; i++)
        {
            spawnPositionsCloseToPlayer[i] = GetClosestPosition(spawnPositionsTemp.ToArray(), _playerManager.Get(0).transform.position);
            spawnPositionsTemp.Remove(spawnPositionsCloseToPlayer[i]);
        }

        if (spawnPositionsCloseToPlayer.Length <= 0)
            return;

        int spawnIndex = UnityEngine.Random.Range(0, _settings.maxSpawnPoints + 1);

        //GameObject enemyObject = _container.InstantiatePrefab(_enemyPrefab, spawnPositionsCloseToPlayer[spawnIndex], Quaternion.identity, null);
        GameObject enemyObject = UnityEngine.Object.Instantiate(_enemyPrefab.gameObject, spawnPositionsCloseToPlayer[spawnIndex], Quaternion.identity, null);

        enemyObject.GetComponent<NetworkObject>().Spawn(true);

        //enemyObject.transform.parent = null;

        _currentEnemies++;
        _spawnTimer = 0;
    }

    private Vector3 GetClosestPosition(Vector3[] positions, Vector3 startPosition)
    {
        Vector3 closestPosition = Vector3.zero;
        float closestRange = -1;

        foreach (Vector3 position in positions)
        {
            float distance = Vector3.Distance(position, startPosition);

            if ((closestRange == -1) || (distance < closestRange))
            {
                closestRange = distance;
                closestPosition = position;
            }
        }

        return closestPosition;
    }

    [Serializable]
    public class Settings
    {
        public int maxEnemies = 6;
        public int maxSpawnPoints = 3;
        public float spawnTime = 3;
    }
}
