using System;
using UnityEngine;

public class RaycastShoot : IShoot
{
    public event TransformEvent OnShoot;

    private readonly Settings _settings;
    private readonly Transform _shootTransform;
    private readonly Transform _muzzleFlashTransform;

    private bool _canShoot = true;
    private float _shotTimer;

    public RaycastShoot(Settings settings, Transform shootTransform, Transform muzzleFlashTransform)
    {
        _settings = settings;
        _shootTransform = shootTransform;
        _muzzleFlashTransform = muzzleFlashTransform;

        _shotTimer = _settings.fireRate;
    }

    public void Shoot()
    {
        if (!_canShoot)
            return;

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

        _canShoot = false;
    }

    public void Update()
    {
        if (_canShoot)
            return;

        _shotTimer -= Time.deltaTime;

        if (_shotTimer <= 0)
        {
            _shotTimer = _settings.fireRate;
            _canShoot = true;
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