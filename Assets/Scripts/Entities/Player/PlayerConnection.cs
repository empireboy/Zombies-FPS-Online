using Unity.Netcode;
using Zenject;

public class PlayerConnection : NetworkBehaviour
{
    private PlayerManager _playerManager;
    private Player _player;

    [Inject]
    public void Construct(PlayerManager playerManager, Player player)
    {
        _playerManager = playerManager;
        _player = player;
    }

    public override void OnNetworkSpawn()
    {
        _playerManager.Add(_player);
    }

    public override void OnNetworkDespawn()
    {
        _playerManager.Remove(_player);
    }
}