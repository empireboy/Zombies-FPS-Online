using UnityEngine;

public delegate void TransformEvent(Transform transform);

public interface IShoot
{
    event TransformEvent OnShoot;

    void Shoot();
    void Update();
}