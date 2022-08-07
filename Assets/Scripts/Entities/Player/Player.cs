using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IShootable, IDamageable
{
    public event DamageEvent OnTakeDamage
    {
        add { _healthHandler.OnTakeDamage += value; }
        remove { _healthHandler.OnTakeDamage -= value; }
    }

    public event TransformEvent OnShoot
    {
        add { _gun.OnShoot += value; }
        remove { _gun.OnShoot -= value; }
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
        transform.position = new Vector3(-26, 4, -16);

        _playerSpawner.Spawn();
    }

    public void Shoot()
    {
        _gun.Shoot();
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