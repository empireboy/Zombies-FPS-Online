using System;
using UnityEngine;
using Zenject;

public class AxisRotator : ITickable
{
	public enum AxisTypes { X, Y, Z };

	private readonly Settings _settings;
	private readonly PlayerInputState _playerInputState;
	private readonly Transform _transform;

	private Vector3 _rotation = Vector3.zero;

	public AxisRotator(Settings settings, PlayerInputState playerInputState, Transform transform)
    {
		_settings = settings;
		_playerInputState = playerInputState;
		_transform = transform;

		_rotation = transform.eulerAngles;
    }

	public void Tick()
    {
		if (_playerInputState.rotation == Vector3.zero)
			return;

		// Get the rotation
		switch (_settings.axis)
		{
			case AxisTypes.X:

				// Add the input or inverted input to the rotation
				_rotation.y += (!_settings.isInverted) ? _playerInputState.rotation.x : -_playerInputState.rotation.x;

				// Clamp the rotation
				if (_settings.isClamped)
				{
					_rotation.y = Mathf.Clamp(_rotation.y, _settings.clampMin, _settings.clampMax);
				}

				break;

			case AxisTypes.Y:

				// Add the input or inverted input to the rotation
				_rotation.x += (!_settings.isInverted) ? _playerInputState.rotation.y : -_playerInputState.rotation.y;

				// Clamp the rotation
				if (_settings.isClamped)
				{
					_rotation.x = Mathf.Clamp(_rotation.x, _settings.clampMin, _settings.clampMax);
				}

				break;

			case AxisTypes.Z:

				// Add the input / inverted input to the rotation
				_rotation.z += (!_settings.isInverted) ? _playerInputState.rotation.z : -_playerInputState.rotation.z;

				// Clamp the rotation
				if (_settings.isClamped)
				{
					_rotation.z = Mathf.Clamp(_rotation.z, _settings.clampMin, _settings.clampMax);
				}

				break;
		}

		// Rotate
		_transform.localRotation = Quaternion.Euler(_rotation);
	}

	[Serializable]
	public class Settings
	{
		[Range(-360f, 359f)]
		public float clampMin = 0f;

		[Range(-360f, 359f)]
		public float clampMax = 359f;

		public AxisTypes axis;
		public bool isInverted;
		public bool isClamped;
	}
}