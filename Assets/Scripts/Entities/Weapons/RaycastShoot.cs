using System;
using UnityEngine;

public class RaycastShoot : IShoot
{
    public event TransformEvent OnStartShooting;
    public event TransformEvent OnStopShooting;
    public event TransformEvent OnShoot;

    private readonly Settings _settings;
    private readonly Transform _shootTransform;
    private readonly Transform _muzzleFlashTransform;

    private bool _isShooting = false;
    private float _shotTimer;

    public RaycastShoot(Settings settings, Transform shootTransform, Transform muzzleFlashTransform)
    {
        _settings = settings;
        _shootTransform = shootTransform;
        _muzzleFlashTransform = muzzleFlashTransform;

        _shotTimer = _settings.fireRate;
    }

    public void StartShooting()
    {
        _isShooting = true;

        OnStartShooting?.Invoke(_muzzleFlashTransform);
    }

    public void StopShooting()
    {
        _isShooting = false;

        OnStopShooting?.Invoke(_muzzleFlashTransform);
    }

    public void Shoot()
    {
        float currentDamage = _settings.damage;

        OnShoot?.Invoke(_muzzleFlashTransform);

        RaycastHit[] raycastHits = Physics.RaycastAll(_shootTransform.position, _shootTransform.forward, _settings.maxDistance, _settings.targetLayerMask);

        // Sort by distance
        Array.Sort(raycastHits, (x, y) => x.distance.CompareTo(y.distance));

        foreach (RaycastHit raycastHit in raycastHits)
        {
            IDamageable damageable = raycastHit.transform.GetComponent<IDamageable>();

            if (damageable == null)
                continue;

            damageable.TakeDamage(currentDamage);

            // Apply falloff
            currentDamage *= _settings.damageFalloff;
        }

        _shotTimer = _settings.fireRate;
    }

    public void Update()
    {
        if (_shotTimer <= 0)
        {
            if (_isShooting)
                Shoot();
        }
        else
        {
            _shotTimer -= Time.deltaTime;
        }
    }

    [Serializable]
    public class Settings
    {
        public float damage;
        public float damageFalloff;
        public float fireRate;
        public float maxDistance;
        public LayerMask targetLayerMask;
    }
}