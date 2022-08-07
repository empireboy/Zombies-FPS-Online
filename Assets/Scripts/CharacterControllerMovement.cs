using System;
using UnityEngine;
using Zenject;

public class CharacterControllerMovement : ITickable
{
	private readonly Settings _settings;
	private readonly PlayerInputState _playerInputState;
	private readonly CharacterController _characterController;

	private float _speedVertical;

	public CharacterControllerMovement(Settings settings, PlayerInputState playerInputState, CharacterController characterController)
    {
		_settings = settings;
		_playerInputState = playerInputState;
		_characterController = characterController;
    }

	public void Tick()
    {
		Vector3 finalVelocity = Vector3.zero;

		// Add forward and sideways movement
		if (_playerInputState.movement != Vector2.zero)
        {
			Vector2 forwardVelocity = new Vector2(
				_characterController.transform.forward.x * _playerInputState.movement.y * _settings.moveSpeed,
				_characterController.transform.forward.z * _playerInputState.movement.y * _settings.moveSpeed
			);

			Vector2 sidewaysVelocity = new Vector2(
				_characterController.transform.right.x * _playerInputState.movement.x * _settings.moveSpeed * _settings.sidewaysMoveSpeedMultiplier,
				_characterController.transform.right.z * _playerInputState.movement.x * _settings.moveSpeed * _settings.sidewaysMoveSpeedMultiplier
			);

			finalVelocity.x = forwardVelocity.x + sidewaysVelocity.x;
			finalVelocity.z = forwardVelocity.y + sidewaysVelocity.y;
		}

		// Add gravity
		_speedVertical = _characterController.isGrounded
			? 0
			: _speedVertical + Physics.gravity.y * _settings.gravity * Time.deltaTime;

		finalVelocity.y = _speedVertical;

		Debug.DrawRay(_characterController.transform.position, finalVelocity, Color.red);

		if (finalVelocity == Vector3.zero)
			return;

		_characterController.Move(finalVelocity * Time.deltaTime);
	}

	[Serializable]
	public class Settings
	{
		public float moveSpeed;
		public float sidewaysMoveSpeedMultiplier;
		public float gravity = 1;
	}
}