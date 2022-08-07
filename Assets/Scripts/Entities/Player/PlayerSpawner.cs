using CM.Debugging;
using UnityEngine;

public class PlayerSpawner
{
    private readonly Transform _transform;

    public PlayerSpawner(Transform transform)
    {
        _transform = transform;
    }

    public void Spawn()
    {
        Vector3 spawnPosition = new Vector3(-26, 4, -16);

        _transform.position = spawnPosition;

        CM_Debug.Log("Player", "Spawning player at " + spawnPosition);
    }
}
