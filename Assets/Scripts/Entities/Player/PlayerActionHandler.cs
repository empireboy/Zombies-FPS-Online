using Zenject;

public class PlayerActionHandler : ITickable
{
    private readonly Player _player;
    private readonly PlayerInputState _playerInputState;

    public PlayerActionHandler(Player player, PlayerInputState playerInputState)
    {
        _player = player;
        _playerInputState = playerInputState;
    }

    public void Tick()
    {
        if (_playerInputState.isShooting)
            _player.Shoot();
    }
}