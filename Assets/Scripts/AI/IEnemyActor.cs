using System;
using UnityEngine;

public interface IEnemyActor : IActor
{
    void Stop();
    void MoveTowards(Func<Vector3> position);
}