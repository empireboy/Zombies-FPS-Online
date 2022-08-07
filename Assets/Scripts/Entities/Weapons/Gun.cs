using UnityEngine;
using Zenject;

public class Gun : MonoBehaviour, IShootable
{
    public event TransformEvent OnShoot
    {
        add { _shootHandler.OnShoot += value; }
        remove { _shootHandler.OnShoot -= value; }
    }

    [SerializeField]
    private GameObject _muzzleFlashPrefab;

    private IShoot _shootHandler;

    [Inject]
    public void Construct(IShoot shootHandler)
    {
        _shootHandler = shootHandler;

        _shootHandler.OnShoot += OnShootInternal;
    }

    public void Shoot()
    {
        _shootHandler.Shoot();
    }

    private void Update()
    {
        if (_shootHandler == null)
            return;

        _shootHandler.Update();
    }

    private void OnShootInternal(Transform muzzleFlashTransform)
    {
        Instantiate(_muzzleFlashPrefab, muzzleFlashTransform.position, muzzleFlashTransform.rotation);
    }
}