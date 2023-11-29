using UnityEngine;

public delegate void TransformEvent(Transform transform);

public interface IShoot
{
    event TransformEvent OnStartShooting;
    event TransformEvent OnStopShooting;
    event TransformEvent OnShoot;

    void StartShooting();
    void StopShooting();
    void Update();
}