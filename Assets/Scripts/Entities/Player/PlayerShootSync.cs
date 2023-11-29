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

        _shootable.OnStartShooting += (transform) =>
        {
            RequestStartShootingServerRpc();
        };

        _shootable.OnStopShooting += (transform) =>
        {
            RequestStopShootingServerRpc();
        };
    }

    [ServerRpc]
    private void RequestStartShootingServerRpc()
    {
        StartShootingClientRpc();
    }

    [ServerRpc]
    private void RequestStopShootingServerRpc()
    {
        StopShootingClientRpc();
    }

    [ClientRpc]
    private void StartShootingClientRpc()
    {
        if (IsOwner)
            return;

        _shootable.StartShooting();
    }

    [ClientRpc]
    private void StopShootingClientRpc()
    {
        if (IsOwner)
            return;

        _shootable.StopShooting();
    }
}