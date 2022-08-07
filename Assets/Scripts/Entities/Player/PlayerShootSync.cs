using Unity.Netcode;

public class PlayerShootSync : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
            return;

        GetComponent<Player>().OnShoot += (transform) =>
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

        GetComponent<Player>().Shoot();
    }
}