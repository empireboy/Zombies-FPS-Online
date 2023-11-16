using CM.Events;
using System;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour, IEnemyActor, IDamageable, IKillable, IComponentContainer, IAnimatable
{
    public ComponentContainer Components { get; set; }
    public IStateController StateController => _stateController;

    public event DamageEvent OnTakeDamage
    {
        add { _health.OnTakeDamage += value; }
        remove { _health.OnTakeDamage -= value; }
    }

    public event SimpleEvent OnKill
    {
        add { _health.OnKill += value; }
        remove { _health.OnKill -= value; }
    }

    private IHealth _health;
    //private DeathHandler _deathHandler;
    private EnemyMovementHandler _enemyMovementHandler;
    private IStateController _stateController;
    private AnimationManager _animationManager;

    [Inject]
    public void Construct(
        IHealth health,
        /*DeathHandler deathHandler,*/
        NavMeshAgentWrapper navMeshAgentWrapper,
        EnemyMovementHandler enemyMovementHandler,
        IStateController stateController,
        AnimationManager animationManager
    )
    {
        _health = health;
        //_deathHandler = deathHandler;
        _enemyMovementHandler = enemyMovementHandler;
        _stateController = stateController;
        _animationManager = animationManager;

        _health.OnKill += Kill;

        Components = new ComponentContainer();
        Components.Add(_health);
        //Components.Add(_deathHandler);
        Components.Add(navMeshAgentWrapper);

        _stateController.SetActor(this);
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }

    public void Kill()
    {
        //_deathHandler.Kill();
    }

    public void Stop()
    {
        _enemyMovementHandler.Stop();
    }

    public void PlayAnimation(string name)
    {
        _animationManager.PlayAnimation(name);
    }

    public void MoveTowards(Func<Vector3> position)
    {
        _enemyMovementHandler.MoveTowards(position);
    }
}