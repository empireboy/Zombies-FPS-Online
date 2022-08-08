using Unity.Netcode;

public class PlayerShootSync : NetworkBehaviour
{
    private IShootable _shootable;

    private void Awake()
    {
        _shootable = GetComponent<IShootable>();
    }

    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
            return;

        _shootable.OnShoot += (transform) =>
        {
            RequestShootServerRpc();
        };
    }

    [ServerRpc]
    private void RequestShootServerRpc()
    {
        ShootClientRpc();
    }

    [ClientRpc]
    private void ShootClientRpc()
    {
        if (IsOwner)
            return;

        _shootable.Shoot();
    }
}