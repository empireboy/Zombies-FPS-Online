using System;
using UnityEngine;
using Zenject;

public class RigidbodyMovement : IFixedTickable
{
	private readonly Settings _settings;
	private readonly PlayerInputState _playerInputState;
	private readonly Rigidbody _rigidbody;

	public RigidbodyMovement(Settings settings, PlayerInputState playerInputState, Rigidbody rigidbody)
    {
		_settings = settings;
		_playerInputState = playerInputState;
		_rigidbody = rigidbody;
    }

	public void FixedTick()
    {
		if (_playerInputState.movement == Vector2.zero)
			return;

		Vector2 forwardVelocity = new Vector2(
			_rigidbody.transform.forward.x * _playerInputState.movement.y * _settings.moveSpeed,
			_rigidbody.transform.forward.z * _playerInputState.movement.y * _settings.moveSpeed
		);

		Vector2 sidewaysVelocity = new Vector2(
			_rigidbody.transform.right.x * _playerInputState.movement.x * _settings.moveSpeed * _settings.sidewaysMoveSpeedMultiplier,
			_rigidbody.transform.right.z * _playerInputState.movement.x * _settings.moveSpeed * _settings.sidewaysMoveSpeedMultiplier
		);

		Vector3 finalVelocity = new Vector3(
			forwardVelocity.x + sidewaysVelocity.x,
			0,
			forwardVelocity.y + sidewaysVelocity.y
		);

		_rigidbody.velocity = finalVelocity * Time.fixedDeltaTime;
	}

	[Serializable]
	public class Settings
	{
		public float moveSpeed;
		public float sidewaysMoveSpeedMultiplier;
	}
}