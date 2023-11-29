using Zenject;

public class PlayerActionHandler : ITickable
{
    private readonly Player _player;
    private readonly PlayerInputState _playerInputState;

    private bool _previousIsShooting;

    public PlayerActionHandler(Player player, PlayerInputState playerInputState)
    {
        _player = player;
        _playerInputState = playerInputState;
    }

    public void Tick()
    {
        if (_playerInputState.isShooting && !_previousIsShooting)
        {
            _player.StartShooting();
        }
        else if (!_playerInputState.isShooting && _previousIsShooting)
        {
            _player.StopShooting();
        }

        _previousIsShooting = _playerInputState.isShooting;
    }
}