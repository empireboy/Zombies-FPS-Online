using CM.Events;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour, IDamageable, IKillable, IComponentContainer
{
    public ComponentContainer Components { get; set; }

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
    private DeathHandler _deathHandler;

    [Inject]
    public void Construct(IHealth health, DeathHandler deathHandler)
    {
        _health = health;
        _deathHandler = deathHandler;

        _health.OnKill += Kill;

        Components = new ComponentContainer();
        Components.Add(_health);
        Components.Add(_deathHandler);
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }

    public void Kill()
    {
        _deathHandler.Kill();
    }
}