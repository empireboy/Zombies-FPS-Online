using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IShootable, IDamageable
{
    public event DamageEvent OnTakeDamage
    {
        add { _healthHandler.OnTakeDamage += value; }
        remove { _healthHandler.OnTakeDamage -= value; }
    }

    public event TransformEvent OnStartShooting
    {
        add { _gun.OnStartShooting += value; }
        remove { _gun.OnStartShooting -= value; }
    }

    public event TransformEvent OnStopShooting
    {
        add { _gun.OnStopShooting += value; }
        remove { _gun.OnStopShooting -= value; }
    }

    [SerializeField]
    private Gun _gun;

    private PlayerSpawner _playerSpawner;
    private IHealth _healthHandler;

    [Inject]
    public void Construct(PlayerSpawner playerSpawner, IHealth healthHandler)
    {
        _playerSpawner = playerSpawner;
        _healthHandler = healthHandler;

        _healthHandler.OnKill += OnKill;

        Spawn();
    }

    public void Spawn()
    {
        _playerSpawner.Spawn();
    }

    public void StartShooting()
    {
        _gun.StartShooting();
    }

    public void StopShooting()
    {
        _gun.StopShooting();
    }

    public void TakeDamage(float damage)
    {
        _healthHandler.TakeDamage(damage);
    }

    private void OnKill()
    {
        Destroy(gameObject);
    }
}