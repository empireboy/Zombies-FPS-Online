using CM.Events;
using System;
using UnityEngine;

public class Health : IHealth
{
    public bool IsActive { get; set; }

    public event DamageEvent OnTakeDamage;
    public event SimpleEvent OnKill;

    private readonly Settings _settings;

    private float _currentHealth;

    public Health(Settings settings)
    {
        _settings = settings;

        _currentHealth = _settings.health;

        IsActive = true;
    }

    public void TakeDamage(float damage)
    {
        if (!IsActive)
            return;

        _currentHealth = Mathf.Max(0, _currentHealth - damage);

        OnTakeDamage?.Invoke(damage);

        if (_currentHealth <= 0)
            Kill();
    }

    public void Kill()
    {
        if (!IsActive)
            return;

        OnKill?.Invoke();
    }

    [Serializable]
    public class Settings
    {
        public float health;
    }
}
