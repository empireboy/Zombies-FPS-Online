using UnityEngine;
using Zenject;

public class Gun : MonoBehaviour, IShootable
{
    public event TransformEvent OnStartShooting
    {
        add { _shootHandler.OnStartShooting += value; }
        remove { _shootHandler.OnStartShooting -= value; }
    }

    public event TransformEvent OnStopShooting
    {
        add { _shootHandler.OnStopShooting += value; }
        remove { _shootHandler.OnStopShooting -= value; }
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

    public void StartShooting()
    {
        _shootHandler.StartShooting();
    }

    public void StopShooting()
    {
        _shootHandler.StopShooting();
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