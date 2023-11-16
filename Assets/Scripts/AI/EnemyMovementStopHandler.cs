using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class EnemyMovementHandler : ITickable
{
    private readonly Settings _settings;

    private readonly NavMeshAgent _agent;
    private readonly Animator _animator;

    private Func<Vector3> _positionFunc;

    public EnemyMovementHandler(Settings settings, NavMeshAgent agent, Animator animator)
    {
        _settings = settings;
        _agent = agent;
        _animator = animator;
    }

    public void Stop()
    {
        _agent.isStopped = true;
    }

    public void MoveTowards(Func<Vector3> positionFunc)
    {
        _positionFunc = positionFunc;

        _agent.speed = UnityEngine.Random.Range(_settings.speedMin, _settings.speedMax);

        _animator.speed = _agent.speed * _settings.walkAnimationMultiplier;
    }

    public void Tick()
    {
        Vector3 position = _positionFunc();

        if (position == null)
            return;

        _agent.SetDestination(position);
    }

    [Serializable]
    public class Settings
    {
        public float speedMin = 1f;
        public float speedMax = 3f;
        public float walkAnimationMultiplier = 1f;
    }
}