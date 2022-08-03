using System;
using UnityEngine;
using Zenject;

public class DamageMultiplier : MonoBehaviour, IDamageable
{
    public event DamageEvent OnTakeDamage
    {
        add { _health.OnTakeDamage += value; }
        remove { _health.OnTakeDamage -= value; }
    }

    public enum DamageType
    {
        Default,
        Head
    }

    [SerializeField]
    private DamageType _damageType;

    private Settings _settings;
    private IHealth _health;

    [Inject]
    public void Construct(Settings settings, IHealth health)
    {
        _settings = settings;
        _health = health;
    }

    public void TakeDamage(float damage)
    {
        switch (_damageType)
        {
            case DamageType.Default:

                damage *= _settings.selfDamageMultiplier;

                break;

            case DamageType.Head:

                damage *= _settings.headSelfDamageMultiplier;

                break;
        }

        _health.TakeDamage(damage);
    }

    [Serializable]
    public class Settings
    {
        public float selfDamageMultiplier = 1;
        public float headSelfDamageMultiplier = 1.5f;
    }
}