using UnityEngine;
using Zenject;

public class PlayerInputHandler : ITickable
{
    private readonly PlayerInputState _playerInputState;

    public PlayerInputHandler(PlayerInputState playerInputState)
    {
        _playerInputState = playerInputState;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Tick()
    {
        _playerInputState.rotation.Set(
            Input.GetAxis("Mouse X"),
            Input.GetAxis("Mouse Y"),
            0
        );

        _playerInputState.movement.Set(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );

        _playerInputState.isShooting = Input.GetMouseButton(0);
    }
}